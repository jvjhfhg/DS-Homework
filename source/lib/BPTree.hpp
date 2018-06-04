#define _CRT_SECURE_NO_WARNINGS
#include<iostream>
#include<cmath>
#include<cstring>
//#include"utility.hpp"
#include<vector>

typedef long long ll;

template<class Key , class T , class Compare = std::less<Key>>
class BPtree{
    private:
    const char* file;
    static const int K = 4096;

    //max1,max2记录的分别是过渡节点、叶子节点的最大空间，min1,min2分别为前者的一半;
	const int max1 = 20; // 2000 * 8 / (sizeof(Key));
	const int max2 = 20; // 2000 * 8 / (sizeof(T));
    const int min1 = max1/2;
    const int min2 = max2/2;
    static const int max0 = 20;

    //节点保存了当前节点的位置，父亲的位置，前驱、后继的位置，一些信息，大小，是否是叶子节点;
    //所有的数组都是0_based;
    class node{
        public:
        ll pos , father , prev , succ;
        Key key[max0];
        ll son[max0];
        T data[max0];
        int size;
        bool is_leaf;
        public:
        node() {
    		pos = father = prev = succ = 0;
    		size = 0;
    		is_leaf = false;
		}
    };

    //保存了BPtree的根节点的位置，以及整个文件的最后位置，每次的插入都从最后开始，从4096开始插入;
    ll root;
    ll at_end = K;
    FILE* File;

    public:
    Compare cmp;

    //开文件，并且定位;
    void file_open(const char* f , ll s){
        File = fopen(f , "rb+");
        fseek(File , s , SEEK_SET);
    }

    //关文件;
    void file_close(){
        fclose(File);
    }

    //构造函数需传参文件指针，默认函数会事先构造一个root;
    BPtree(const char* f):file(f){
        node rt;
        rt.pos = at_end;
        at_end += K;
        root = rt.pos;
        file_open(file , rt.pos);
        fwrite((char*)(&rt) , K , 1 , File);
        file_close();
    }

    //删库跑路;
    void clear(){

		File = fopen(file , "w");
        fclose(File);
    }

    //在当前块中查找键值所在位置，若键值小于当前的第一个键值，则返回-1;
    int search(Key& kk , node* ss){
        if(cmp(kk , ss->key[0])){
            return -1;
        }
        for(int i = 0 ; i < ss->size ; ++i){
            if(cmp(kk , ss->key[i])){
                return i;
            }
        }
        return ss->size;
    }

    //在所有块中查找键值所在位置，只会找到对应的块的位置，不能查找在头的;
    ll search_node(Key& kk){
        char* tmp[K];
        file_open(file , root);
        fread(tmp , K , 1 , File);
        file_close();
        node* st = (node*) tmp;
        while(!st->is_leaf){
            int p = search(kk , st) - 1;
            file_open(file , st->son[p]);
            fread(tmp , K , 1 , File);
            file_close();
            st = (node*) tmp;
        }
        return st->pos;
    }

    //查找主函数;
    std::pair<T& , bool> query(Key& kk){

		char* tmp[4096];
        ll p = search_node(kk);
        file_open(file , p);
        fread(tmp , K , 1 , File);
        node* now = (node*) tmp;
        file_close();
        int k = search(kk , now);
        if(k == -1)  return std::pair<T& , bool>(now->data[0] , false);
        else{
            if(!(cmp(now->key[k] , kk)) && !(cmp(kk , now->key[k]))){
                return std::pair<T& , bool> (now->data[k] , true);
            }
            else{
                return std::pair<T& , bool> (now->data[k] , true); 
            }
        }
    }

    //中序遍历
    std::vector<std::pair<Key , T&>> traverse(node* s , std::vector<std::pair<Key , T&>> a){
        char* tmp[4096];
        if(s->is_leaf){
            for(int i = 0 ; i < s->size ; ++i){
                a.push_back(std::pair<Key , T&>(s->key[i] , s->data[i]));
            }
        }
        else{
            for(int i = 0 ; i < s->size ; ++i){
                file_open(file , s->son[i]);
                fread(tmp , K , 1 , File);
                file_close();
                node* now = (node*) tmp;
                traverse(now , a);
            }
        }
    }

    std::vector<std::pair<Key , T&>> traverse(){
        char* tmp[K];
        file_open(file , root);
        fread(tmp , K , 1 , File);
        file_close();
        node* rt = (node*) tmp;
        std::vector<std::pair<Key , T&>> s;
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
		if (s->pos == root)  return;
        char* tmp[K];
        file_open(file , s->father);
        fread(tmp , K , 1 , File);
        node* fa = (node*) tmp;
        file_close();
        int k = search(s->key[0] , fa);
        if(!(cmp(fa->key[k] , s->key[0])) && !(cmp(s->key[0] , fa->key[k])))  return;
        else{
            move_back(k , fa);
            fa->key[k] = s->key[0];
            fa->son[k] = s->pos;
            file_open(file , fa->pos);
            fwrite((char*) fa , K , 1 , File);
            file_close();
            update_father(fa);
        }
    }

    //更新一个节点的父亲的键值，若相等则不作为，若不等则修改;
    void update_father(node* s){
        char* tmp[K];
        file_open(file , s->father);
        fread(tmp , K , 1 , File);
        file_close();
        node* fa = (node*) tmp;
        for(int i = 0 ; i < fa->size ; ++i){
            if(fa->son[i] == s->pos){
                if(fa->key[i] == s->key[0])  return;
                else{
                    fa->key[i] = s->key[0];
                    file_open(file , fa->pos);
                    fwrite((char*)fa , K , 1 , File);
                    file_close();
                    update_father(fa);
					return;
                }
            }
        }
    }

    //更新一个块的儿子的父亲;
    void update_son(node* s , int k){
        if(s->is_leaf)  return;
        char* tmp[K];
        file_open(file , s->son[k]);
        fread(tmp , K , 1 , File);
        file_close();
        node* so = (node*) tmp;
        so->father = s->pos;
        file_open(file , so->pos);
        fwrite((char*)so , K , 1 , File);
        file_close();
    }

    //分裂新块;
    void divide(node* a , int p){
        char*tmp[K];
        node new_node;
        if(a->succ == 0){
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
            fwrite((char*)(&new_node) , K , 1 , File);
            fseek(File , a->pos , SEEK_SET);
            fwrite((char*) a , K , 1 , File);
            file_close();
        }
        else{
            file_open(file , a->succ);
            fread(tmp , K , 1 , File);
            file_close();
            node* su = (node*) tmp;
            new_node.pos = at_end;
            at_end += K;
            new_node.father = a->father;
            new_node.prev = a->pos;
            new_node.succ = su->pos;
            su->prev = new_node.pos;
            a->succ = new_node.pos;
            file_open(file , su->pos);
            fwrite((char*)su , K , 1 , File);
            file_close();
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
            fwrite((char*)(&new_node) , K , 1 , File);
            fseek(File , a->pos , SEEK_SET);
            fwrite((char*) a , K , 1 , File);
            file_close();
        }
        add_father(&new_node);
    }

    //插入主函数
    bool insert(Key& kk , T& dd){
        char* tmp[4096];
        ll nn;
        file_open(file , root);
        fread(tmp , K , 1 , File);
        file_close();
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
            fwrite((char*)(&new_node) , K , 1 , File);
            fseek(File , root , SEEK_SET);
            fwrite((char*)rt , K , 1 , File);
            file_close();
            return true;
        }
        node* now;
        if(cmp(kk , rt->key[0])){
            ll p = search_node(rt->key[0]);
            file_open(file , p);
            fread(tmp , K , 1 , File);
            file_close();
            now =  (node*) tmp;
            move_back(0 , now);
            now->key[0] = kk;
            now->data[0] = dd;
            update_father(now);
            now->size++;
            file_open(file , now->pos);
            fwrite((char*)now , K , 1 , File);
            file_close();
        }
        else{
            ll p = search_node(kk);
            file_open(file , p);
            fread(tmp , K , 1 , File);
            file_close();
            now = (node*) tmp;
            int k = search(kk , now);
            if(!(cmp(now->key[0] , kk)) && !(cmp(kk , now->key[0]))){
                return false;
            }
            else{
                move_back(k , now);
                now->key[k] = kk;
                now->data[k] = dd;
                file_open(file , now->pos);
                fwrite((char*)now , K , 1 , File);
                file_close();
            }
        }
        while(now->pos != root){
            if(now->is_leaf && now->size < max2)  break;
            if(!(now->is_leaf) && now->size < max1)  break;
            divide(now , max0/2);
            file_open(file , now->father);
            fread(tmp , K , 1 , File);
            file_close();
        	node* fa = (node*) tmp;
			now = fa; 
        }
        if(now->pos != root)  return true;
        else{
			if (now->size < max1)  return true;
			else {
				node new_root;
				new_root.pos = at_end;
				at_end += K;
				root = new_root.pos;
				new_root.key[0] = now->key[0];
				new_root.data[0] = now->pos;
				now->father = new_root.pos;
				file_open(file, now->pos);
				fwrite((char*)now, K, 1, File);
				fseek(File, new_root.pos, SEEK_SET);
				fwrite((char*)(&new_root), K, 1, File);
				file_close();
				divide(now, max0 / 2);
				return true;
			}
        }
    }

    //修改主函数;
    void modify(Key& kk , T& dd){
        char* tmp[4096];
        ll p = search_node(kk);
        file_open(file , p);
        fread(tmp , K , 1 , File);
        file_close();
        node* now = (node*) tmp;
        int k = search(kk , now);
        now->key[k] = kk;
        now->data[k] = dd;
        update_father(now);
        file_open(file , now->pos);
        fwrite((char*)now , K , 1 , File);
        file_close();
    }

    //向左兄弟借儿子，若前者有足够的返回true;
    bool borrow_left(node* a){
        char* tmp[K];
        file_open(file , a->prev);
        fread(tmp , K , 1 , File);
        file_close();
        node* pr = (node*) tmp;
        if(pr->is_leaf){
            if(pr->size > max2/2){
                pr->size -= 1;
                move_back(0 , a);
                a->key[0] = pr->key[pr->size];
                a->data[0] = pr->data[pr->size];
                file_open(file , a->pos);
                fwrite((char*)a , K , 1 , File);
                file_close();
                update_father(a);
                file_open(file , pr->pos);
                fwrite((char*)pr , K , 1 , File);
                file_close();
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
                fwrite((char*)a , K , 1 , File);
                file_close();
                update_father(a);
                file_open(file , pr->pos);
                fwrite((char*)pr , K , 1 , File);
                file_close();
                return true;
            }
            else{
                return false;
            }
        }
    }

    //向右子树借一个孩子;
    bool borrow_right(node* a){
        char* tmp[K];
        file_open(file , a->succ);
        fread(tmp , K , 1 , File);
        file_close();
        node* su = (node*) tmp;
        if(su->is_leaf){
            if(su->size > max1/2){
                a->key[a->size] = su->key[0];
                a->data[a->size] = su->data[0];
                a->size += 1;
                move_front(1 , su);
                file_open(file , su->pos);
                fwrite((char*)su , K , 1 , File);
                file_close();
                update_father(su);
                file_open(file , a->pos);
                fwrite(a , K , 1 , File);
                file_close();
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
                fwrite((char*)su , K , 1 , File);
                file_close();
                update_father(su);
                file_open(file , a->pos);
                fwrite(a , K , 1 , File);
                file_close();
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
        file_open(file , s->prev);
        fread(tmp , K , 1 , File);
        node* pr = (node*) tmp;
        file_close();
        if(s->is_leaf){
            for(int i = 0 ; i < s->size ; ++i){
                pr->key[pr->size + i] = s->key[i];
                pr->data[i + pr->size] = s->data[i];
            }
            pr->size += s->size;
            if(s->succ != 0){
                file_open(file , s->succ);
                fread(tmp , K , 1 , File);
                file_close();
                node* susu = (node*) tmp;
                susu->prev = pr->pos;
                pr->succ = susu->pos;
            }
            else{
                pr->succ = 0;
            }
            file_open(file , pr->father);
            fread(tmp , K , 1 , File);
            file_close();
            node* fa = (node*) tmp;
            int k = search(s->key[0] , fa);
            move_front(k + 1 , fa);
            file_open(file , fa->pos);
            fwrite((char*) fa , K , 1 , File);
            fseek(File , pr->pos , SEEK_SET);
            fwrite((char*) pr , K , 1 , File);
            file_close();
        }
        else{
            for(int i = 0 ; i < s->size ; ++i){
                pr->key[pr->size + i] = s->key[i];
                pr->son[i + pr->size] = s->son[i];
                update_son(pr , pr->size + i);
            }
            pr->size += s->size;
            if(s->succ != 0){
                file_open(file , s->succ);
                fread(tmp , K , 1 , File);
                file_close();
                node* susu = (node*) tmp;
                susu->prev = pr->pos;
                pr->succ = susu->pos;
            }
            else{
                pr->succ = 0;
            }
            file_open(file , pr->father);
            fread(tmp , K , 1 , File);
            file_close();
            node* fa = (node*) tmp;
            int k = search(s->key[0] , fa);
            move_front(k + 1 , fa);
            file_open(file , fa->pos);
            fwrite((char*) fa , K , 1 , File);
            fseek(File , pr->pos , SEEK_SET);
            fwrite((char*) pr , K , 1 , File);
            file_close();
        }
    }

    void merge_right(node* s){
        char* tmp[K];
        file_open(file , s->succ);
        fread(tmp , K , 1 , File);
        file_close();
        node* su = (node*) tmp;
        if(s->is_leaf){
            for(int i = 0 ; i < su->size ; ++i){
                s->key[i + s->size] = su->key[i];
                s->data[i + s->size] = su->data[i];
            }
            s->size += su->size;
            if(su->succ != 0){
                file_open(file , su->succ);
                fread(tmp , K , 1 , File);
                file_close();
                node* susu = (node*) tmp;
                susu->prev = s->pos;
                s->succ = susu->pos;
            }
            else{
                s->succ = 0;
            }
            file_open(file , s->father);
            fread(tmp , K , 1 , File);
            file_close();
            node* fa = (node*)tmp;
            int k = search(su->key[0] , fa);
            move_front(k + 1 , fa);
            file_open(file , fa->pos);
            fwrite((char*) fa , K , 1 , File);
            fseek(File , s->pos , SEEK_SET);
            fwrite((char*) s , K , 1 , File);
            file_close();
        }
    }

    //合并主函数;
    void merge(node* s){
        char* tmp[K];
        if(s->is_leaf){
            if(s->size < max2/2){
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
        char* tmp[4096];
        ll p = search_node(kk);
        file_open(file , p);
        fread(tmp , K , 1 , File);
        file_close();
        node* now = (node*) tmp;
        if(now->size == 1){
            if(now->prev == 0 && now->succ == 0){
                file_open(file , now->father);
                fread(tmp , K , 1 , File);
                file_close();
                node* fa = (node*) tmp;
                fa->size = 0;
                file_open(file , fa->pos);
                fwrite((char*) fa , K , 1 , File);
                file_close();
                return;
            }
            if(now->prev == 0){
                file_open(file , now->succ);
                fread(tmp , K , 1 , File);
                node* su = (node*) tmp;
                fseek(File , now->father , SEEK_SET);
                fread(tmp , K , 1 , File);
                node* fa = (node*) tmp;
                file_close();
                int k = search(kk , fa);
                move_front(k + 1 , fa);
                su->prev = 0;
                file_open(file , fa->pos);
                fwrite((char*) fa , K , 1 , File);
                fseek(File , su->pos , SEEK_SET);
                fwrite((char*) su , K , 1 , File);
                file_close();
                return;
            }
            if(now->succ == 0){
                file_open(file , now->prev);
                fread(tmp , K , 1 , File);
                node* pr = (node*) tmp;
                fseek(File , now->father , SEEK_SET);
                fread(tmp , K , 1 , File);
                node* fa = (node*) tmp;
                file_close();
                int k = search(kk , fa);
                move_front(k + 1 , fa);
                pr->succ = 0;
                file_open(file , fa->pos);
                fwrite((char*) fa , K , 1 , File);
                fseek(File , pr->pos , SEEK_SET);
                fwrite((char*) pr , K , 1 , File);
                file_close();
                return;
            }
        }
        int k = search(kk , now);
        move_front(k , now);
        update_father(now);
        file_open(file , now->pos);
        fwrite((char*) now , K , 1 , File);
        file_close();
        merge(now);
    }
};
