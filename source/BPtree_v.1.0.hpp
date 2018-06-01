#include<iostream>
#include<cmath>
#include<cstring>
#include"utility.hpp"
#include"vector.hpp"

typedef long long ll;

template<class Key , class T , class Compare = std::less<Key>>
class BPtree{
    private:
    const char* file;
    const int K = 4096;

    //max1,max2记录的分别是过渡节点、叶子节点的最大空间，min1,min2分别为前者的一半;
    const int max1 = 2000*8/(sizeof(Key));
    const int max2 = 2000*8/(sizeof(T));
    const int min1 = max1/2;
    const int min2 = max2/2;
    if(max1 >= max2)  const int max0 = max2;
    else  const int max0 = max1;

    //节点保存了当前节点的位置，父亲的位置，前驱、后继的位置，一些信息，大小，是否是叶子节点;
    //所有的数组都是0_based;
    class node{
        private:
        ll pos = 0 , father = 0 , prev = 0 , succ = 0;
        Key key[max0];
        ll son[max0];
        T data[max0];
        int size = 0;
        bool is_leaf = false;
    };

    //保存了BPtree的根节点的位置，以及整个文件的最后位置，每次的插入都从最后开始，从4096开始插入;
    ll root;
    ll at_end = K;

    public:
    Compare cmp;

    //开文件，并且定位;
    void file_open(const char* f , ll s){
        fopen(file , "rb+");
        fseek(file , s , SEEK_SET);
    }

    //关文件;
    void file_close(const char* f){
        fclose(file);
    }

    //构造函数需传参文件指针，默认函数会事先构造一个root;
    BPtree(const char* f):file(f){
        node rt;
        rt.pos = at_end;
        at_end += K;
        root = rt.pos;
        file_open(f , rt.pos);
        fwrite((char*)(&rt) , K , 1 , f);
        file_close(f);
    }

    //删库跑路;
    void clear(){
        fopen(file , "w");
        fclose(file);
    }

    //在当前块中查找键值所在位置，若键值小于当前的第一个键值，则返回-1;
    int search(Key& kk , node* ss){
        if(cmp(kk , ss->key[0])){
            return -1;
        }
        for(int i = 0 ; i < ss->size ; ++i){
            if(cmp(kk , ss->key[i])){
                return i - 1;
            }
        }
        return ss->size - 1;
    }

    //在所有块中查找键值所在位置，只会找到对应的块的位置，不能查找在头的;
    ll search_node(Key& kk){
        char* tmp[K];
        file_open(file , root);
        fread(tmp , K , 1 , file);
        file_close(file);
        node* st = (node*) tmp;
        while(!st->is_leaf){
            int p = search(kk , st);
            file_open(f , st->son[p]);
            fread(tmp , K , 1 , file);
            file_close(file);
            st = (node*) tmp;
        }
        return st->pos;
    }

    //查找主函数;
    pair<T& , bool> query(Key& kk){
        char* tmp[K];
        ll p = search_node(kk);
        file_open(file , p);
        fread(tmp , K , 1 , file);
        node* now = (node*) tmp;
        file_close(file);
        int k = search(kk , now);
        if(k == -1)  return pair<T& , bool>(now->key[0] , false);
        else{
            if(!(cmp(now->key[k] , kk)) && !(cmp(kk , now->key[k]))){
                return pair<T& , bool> (now->key[k] , true);
            }
            else{
                return pair<T& , bool> (now->key[k] , true); 
            }
        }
    }

    //中序遍历
    vector<pair<Key , T&>> traverse(node* s , vector<pair<Key , T&>> a){
        char* tmp[K];
        if(s->is_leaf){
            for(int i = 0 ; i < s->size ; ++i){
                a.push_back(pair<Key , T&>(s->key[i] , s->data[i]));
            }
        }
        else{
            for(int i = 0 ; i < s->size ; ++i){
                file_open(file , s->son[i]);
                fread(tmp , K ,1 , file);
                file_close(file);
                node* now = (node*) tmp;
                traverse(now , a);
            }
        }
    }

    vector<pair<Key , T&>> traverse(){
        char* tmp[K];
        file_open(file , root);
        fread(tmp , K , 1 , file);
        file_close(file);
        node* rt = (node*) tmp;
        vector<pair<Key , T&>> s;
        traverse(rt , s);
        return s;
    }

    //将一个块中第几个元素及其之后的元素后移一个;
    void move_back(int k , node* ss){
        for(int i = ss->size ; i > k ; --i){
            if(ss->is_leaf){
                ss->key[i] = ss->key[i - 1];
                ss->data[i] = ss->data[i - 1];
            }
            else{
                ss->key[i] = ss->key[i - 1];
                ss->son[i] = ss->son[i - 1];
            }
        }
        ss->size++;
    }

    //将一个块中第几个元素及其之后的元素前移一个;
    void move_front(int k , node* ss){
        for(int i = k - 1 ; i < ss->size - 1 ; ++i){
            if(ss->is_leaf){
                ss->key[i] = ss->key[i + 1];
                ss->data[i] = ss->data[i + 1];
            }
            else{
                ss->key[i] = ss->key[i + 1];
                ss->data[i] = ss->data[i + 1];
            }
        }
        ss->size--;
    }

    //在这个节点的父亲节点的儿子里加入这个节点，若已经存在该节点，则不作为;
    void add_father(node* s){
        char* tmp[K];
        file_open(file , s->father);
        fread(tmp , K , 1 , file);
        node* fa = (node*) tmp;
        file_close(file);
        int k = search(s->key[0] , fa);
        if(!(cmp(fa->key[k] , s->key[0])) && !(cmp(s->key[0] , fa->key[k])))  return;
        else{
            move_back(k + 2 , fa);
            fa->key[k + 1] = s->key[0];
            fa->son[k + 1] = s->pos;
            file_open(file , fa->pos);
            fwrite((char*) fa , K , 1 , file);
            file_close(file);
            update_father(fa);
        }
    }

    //更新一个节点的父亲的键值，若相等则不作为，若不等则修改;
    void update_father(node* s){
        char* tmp[K];
        file_open(file , s->father);
        fread(tmp , K , 1 , file);
        file_close(file);
        node* fa = (node*) tmp;
        for(int i = 0 ; i < fa->size ; ++i){
            if(fa->son[i] == s->pos){
                if(fa->key[i] == s->key[0])  return;
                else{
                    fa->key[i] = s->key[0];
                    file_open(file , fa->pos);
                    fwrite((char*)fa , K , 1 , file);
                    file_close(file);
                    update_father(fa);
                }
            }
        }
    }

    //更新一个块的儿子的父亲;
    void update_son(node* s , int k){
        if(s->is_leaf)  return;
        char* tmp[K];
        file_open(file , s->son[k]);
        fread(tmp , K , 1 , file);
        file_close(file);
        node* so = (node*) tmp;
        so->father = s->pos;
        file_open(file , so->pos);
        fwrite((char*)so , K , 1 , file);
        file_close(file);
    }

    //分裂新块;
    void divide(node* a , int p){
        char*tmp[K];
        if(a->succ == 0){
            node new_node;
            new_node.pos = at_end;
            at_end += K;
            new_node.father = a->father;
            new_node.prev = a->pos;
            a->succ = new_node.pos;
            for(int i = p ; i < a->size ; ++i){
                new_node.key[i - p] = a->key[i];
                new_node.son[i - p] = a->son[i];
                new_node.data[i - p] = a->data[i];
                update_son(&new_node , i - p);
            }
            new_node.size = a->size - p;
            a->size = p;
            if(a->is_leaf)  new_node.is_leaf = true;
            else  new_node.is_leaf = false;
            file_open(file , new_node.pos);
            fwrite((char*)(&new_node) , K , 1 , file);
            fseek(file , a->pos , SEEK_SET);
            fwrite((char*) a , K , 1 , file);
            file_close(file);
        }
        else{
            file_open(file , a->succ);
            fread(tmp , K , 1 , file);
            file_close(file);
            node* su = (node*) tmp;
            node new_node;
            new_node.pos = at_end;
            at_end += K;
            new_node.father = a->father;
            new_node.prev = a->pos;
            new_node.succ = su->pos;
            su->prev = new_node.pos;
            a->succ = new_node.pos;
            file_open(file , su->pos);
            fwrite((char*)su , K , 1 , file);
            file_close(file);
            for(int i = p ; i < a->size ; ++i){
                new_node.key[i - p] = a->key[i];
                new_node.son[i - p] = a->son[i];
                new_node.data[i - p] = a->data[i];
                update_son(&new_node , i - p);
            }
            new_node.size = a->size - p;
            a->size = p;
            if(a->is_leaf)  new_node.is_leaf = true;
            else  new_node.is_leaf = false;
            file_open(file , new_node.pos);
            fwrite((char*)(&new_node) , K , 1 , file);
            fseek(file , a->pos , SEEK_SET);
            fwrite((char*) a , K , 1 , file);
            file_close(file);
        }
        add_father(new_node.pos);
    }

    //插入主函数
    bool insert(Key& kk , T& dd){
        char* tmp[K];
        ll nn;
        file_open(file , root);
        fread(tmp , K , 1 , file);
        fclose(file);
        node* rt = (node*) tmp;
        if(rt->size == 0){
            node new_node;
            new_node.pos = at_end;
            at_end += K;
            new_node.father = root;
            new_node.key[0] = kk;
            new_node.data[0] = dd;
            new_node.size = 1;
            new_node.is_leaf = true;
            rt->key[0] = kk;
            rt->son[0] = new_node.pos;
            rt->size++;
            file_open(file , new_node.pos);
            fwrite((char*)(&new_node) , K , 1 , file);
            fseek(file , root , SEEK_SET);
            fwrite((char*)rt , K , 1 , file);
            file_close(file);
            return true;
        }
        if(cmp(kk , rt->key[0])){
            ll p = search_node(rt->key[0]);
            file_open(file , p);
            fread(tmp , K , 1 , file);
            fclose(file);
            node* now =  (node*) tmp;
            move_back(now , 0);
            now->key[0] = kk;
            now->data[0] = dd;
            update_father(now);
            now->size++;
            file_open(file , now->pos);
            fwrite((char*)now , K , 1 , file);
            fclose(file);
        }
        else{
            ll p = search_node(kk);
            file_open(file , p);
            fread(tmp , K , 1 , file);
            file_close(file);
            node* now = (node*) tmp;
            int k = search(kk , now);
            if(!(cmp(now->key[0] , kk)) && !(cmp(kk , now->key[0]))){
                return false;
            }
            else{
                move_back(now , k);
                now->key[k] = kk;
                now->data[k] = dd;
                now->size++;
                file_open(file , now->pos);
                fwrite((char*)now , K , 1 , file);
                file_close(file);
            }
        }
        while(now->pos != root){
            if(now->is_leaf && now->size < max2)  break;
            if(!(now->is_leaf) && now->size < max1)  break;
            divide(now , max0/2);
            now = now->father; 
        }
        if(now->pos != root)  return true;
        else{
            node new_root;
            new_root.pos = at_end;
            at_end += K;
            root = new_root.pos;
            new_root.key[0] = now->key[0];
            new_root.data[0] = now->pos;
            now->father = new_root;
            file_open(file , now->pos);
            fwrite((char*)now , K , 1 , file);
            fseek(file , new_root.pos , SEEK_SET);
            fwrite((char*)(&new_root) , K , 1 , file);
            file_close(file);
            divide(now , max0/2);
        }
    }

    //修改主函数;
    void modify(Key& kk , T& dd){
        char* tmp[K];
        ll p = search_node(kk);
        file_open(file , p);
        fread(tmp , K , 1 , file);
        file_close(file);
        node* now = (node*) tmp;
        int k = search(kk , now);
        now->key[k] = kk;
        now->data[k] = dd;
        update_father(now);
        file_open(file , now->pos);
        fwrite((char*)now , K , 1 , file);
        file_close(file);
    }

    //向左兄弟借儿子，若前者有足够的返回true;
    bool borrow_left(node* a){
        char* tmp[K];
        file_open(file , a->prev);
        fread(tmp , K , 1 , file);
        file_close(file);
        node* pr = (node*) tmp;
        if(pr->is_leaf){
            if(pr->size > max2/2){
                pr->size -= 1;
                move_back(0 , a);
                a->key[0] = pr->key[pr->size];
                a->data[0] = pr->data[pr->size];
                file_open(file , a->pos);
                fwrite((char*)a , K , 1 , file);
                file_close(file);
                update_father(a);
                file_open(file , pr->pos);
                fwrite((char*)pr , K , 1 , file);
                file_close(file);
                return true;
            }
            else{
                return false;
            }
        }
        else{
            if(pr->size > max2/2){
                pr->size -= 1;
                move_back(0 , a);
                a->key[0] = pr->key[pr->size];
                a->son[0] = pr->son[pr->size];
                file_open(file , a->pos);
                fwrite((char*)a , K , 1 , file);
                file_close(file);
                update_father(a);
                file_open(file , pr->pos);
                fwrite((char*)pr , K , 1 , file);
                file_close(file);
                return true;
            }
            else{
                return false;
            }
        }
    }

    //向右子树借一个孩子;
    void borrow_right(node* a){
        char* tmp[K];
        file_open(file , a->succ);
        fread(tmp , K , 1 , file);
        file_close(file);
        node* su = (node*) tmp;
        if(su->is_leaf){
            if(su->size > max1/2){
                a->key[a->size] = su->key[0];
                a->data[a->size] = su->data[0];
                a->size += 1;
                move_front(1 , su);
                file_open(file , su->pos);
                fwrite((char*)su , K , 1 , file);
                file_close(file);
                update_father(su);
                file_open(file , a->pos);
                fwrite(a , K , 1 , file);
                file_close(file);
                return true;
            }
            else{
                return false;
            }
        }
        else{
            if(su->size > max1/2){
                a->key[a->size] = su->key[0];
                a->son[a->size] = su->son[0];
                a->size += 1;
                move_front(1 , su);
                file_open(file , su->pos);
                fwrite((char*)su , K , 1 , file);
                file_close(file);
                update_father(su);
                file_open(file , a->pos);
                fwrite(a , K , 1 , file);
                file_close(file);
                return true;
            }
            else{
                return false;
            }
        }
    }

    //合并两个块;
    void merge_left(node* s){
        char* tmp[K];
        file_open(file , a->prev);
        fread(tmp , K , 1 , file);
        node* pr = (node*) tmp;
        file_close(file);
        if(s->is_leaf){
            for(int i = 0 ; i < s->size ; ++i){
                pr->key[pr->size + i] = s->key[i];
                pr->data[i + pr->size] = s->data[i];
            }
            pr->size += s->size;
            if(s->succ != 0){
                file_open(file , a->succ);
                fread(tmp , K , 1 , file);
                file_close(file);
                node* susu = (node*) tmp;
                susu->prev = pr;
                pr->succ = susu;
            }
            else{
                pr->succ = 0;
            }
            file_open(file , pr->father);
            fread(tmp , K , 1 , file);
            file_close(file);
            node* fa = (node*) tmp;
            int k = search(s->key[0] , fa);
            move_front(k + 1 , fa);
            file_open(file , fa->pos);
            fwrite((char*) fa , K , 1 , file);
            fseek(file , pr->pos , SEEK_SET);
            fwrite((char*) pr , K , 1 , file);
            file_close(file);
        }
        else{
            for(int i = 0 ; i < s->size ; ++i){
                pr->key[pr->size + i] = s->key[i];
                pr->son[i + pr->size] = s->son[i];
                updata_son(pr , pr->size + i);
            }
            pr->size += s->size;
            if(s->succ != 0){
                file_open(file , a->succ);
                fread(tmp , K , 1 , file);
                file_close(file);
                node* susu = (node*) tmp;
                susu->prev = pr;
                pr->succ = susu;
            }
            else{
                pr->succ = 0;
            }
            file_open(file , pr->father);
            fread(tmp , K , 1 , file);
            file_close(file);
            node* fa = (node*) tmp;
            int k = search(s->key[0] , fa);
            move_front(k + 1 , fa);
            file_open(file , fa->pos);
            fwrite((char*) fa , K , 1 , file);
            fseek(file , pr->pos , SEEK_SET);
            fwrite((char*) pr , K , 1 , file);
            file_close(file);
        }
    }

    void merge_right(node* s){
        char* tmp[K];
        file_open(file , s->succ);
        fread(tmp , K , 1 , file);
        file_close(file);
        node* su = (node*) tmp;
        if(s->is_leaf){
            for(int i = 0 ; i < su->size ; ++i){
                s->key[i + s->size] = su->key[i];
                s->data[i + s->size] = su->data[i];
            }
            s->size += su->size;
            if(su->succ != 0){
                file_open(file , su->succ);
                fread(tmp , K , 1 , file);
                file_close(file);
                node* susu = (node*) tmp;
                susu->prev = s;
                s->succ = susu;
            }
            else{
                s->succ = 0;
            }
            file_open(file , s->father);
            fread(tmp , K , 1 , file);
            file_close(file);
            node* fa = (node*)tmp;
            int k = search(su->key[0] , fa);
            move_front(k + 1 , fa);
            file_open(file , fa->pos);
            fwrite((char*) fa , K , 1 , file);
            fseek(file , s->pos , SEEK_SET);
            fwrite((char*) s , K , 1 , file);
            file_close(file);
        }
    }

    //合并主函数;
    void merge(node* s){
        char* tmp[K];
        if(s->is_leaf){
            if(s->size < max2){
                if(s->prev != 0){
                    bool flag = borrow_left(s);
                    if(!flag)  merge_left(s);
                    return;
                }
                if(s->succ != 0){
                    bool flag = borrow_right(s);
                    if(!flag)  merge_right(s);
                    return;
                }
            }
            else  return;
        }
        else{
            if(s->size < max1){
                if(s->prev != 0){
                    bool flag = borrow_left(s);
                    if(!flag)  merge_left(s);
                    return;
                }
                if(s->succ != 0){
                    bool flag = borrow_right(s);
                    if(!flag)  merge_right(s);
                    return;
                }
            }
            else  return;
        }
    }

    //删除主函数;
    void erase(Key& kk){
        char* tmp[K];
        ll p = search_node(kk);
        file_open(file , p);
        fread(tmp , K , 1 , file);
        file_close(file);
        node* now = (node*) tmp;
        if(now->size == 1){
            if(now->prev == 0 && now->succ == 0){
                file_open(file , now->father);
                fread(tmp , K , 1 , file);
                file_close(file);
                node* fa = (node*) tmp;
                fa->size = 0;
                file_open(file , fa->pos);
                fwrite((char*) fa , K , 1 , file);
                file_close(file);
                return;
            }
            if(now->prev == 0){
                file_open(file , now->succ);
                fread(tmp , K , 1 , file);
                node* su = (node*) tmp;
                fseek(file , now->father , SEEK_SET);
                fread(tmp , K , 1 , file);
                node* fa = (node*) tmp;
                file_close(file);
                int k = search(kk , fa);
                move_front(k + 1 , fa);
                su->prev = 0;
                file_open(file);
                fwrite((char*) fa , K , 1 , file);
                fseek(file , su->pos , SEEK_SET);
                fwrite((char*) su , K , 1 , file);
                file_close(file);
                return;
            }
            if(now->succ == 0){
                file_open(file , now->prev);
                fread(tmp , K , 1 , file);
                node* pr = (node*) tmp;
                fseek(file , now->father , SEEK_SET);
                fread(tmp , K , 1 , file);
                node* fa = (node*) tmp;
                file_close(file);
                int k = search(kk , fa);
                move_front(k + 1 , fa);
                pr->succ = 0;
                file_open(file);
                fwrite((char*) fa , K , 1 , file);
                fseek(file , pr->pos , SEEK_SET);
                fwrite((char*) pr , K , 1 , file);
                file_close(file);
                return;
            }
        }
        int k = search(kk , now);
        move_front(k + 1 , now);
        update_father(now);
        file_open(file , now->pos);
        fwrite((char*) now , K , 1 , file);
        file_close(file);
        merge(now);
    }
};