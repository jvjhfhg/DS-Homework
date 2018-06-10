#pragma once
#include<fstream>
#include<iostream>
#include"lib/b_plus_tree.hpp"
#include"lib/algorithm.hpp"
#include"lib/utility.hpp"
namespace sjtu
{
class user_data
{
public:
    string _User_Name;
    string _Password;
    string _Email;
    string _Phone;
    int _Privilege;
    user_data() = default;
    user_data(const char* a, const char* b, const char* c, const char* d, int e = 1)
    : _User_Name(a), _Password(b), _Email(c), _Phone(d), _Privilege(e) {}
    user_data(const user_data& o): _User_Name(o._User_Name), _Password(o._Password), _Email(o._Email), _Phone(o._Phone), _Privilege(o._Privilege) {}
    user_data operator = (const user_data& o)
    {
        _User_Name = o._User_Name;
        _Password = o._Password;
        _Email = o._Email;
        _Phone = o._Phone;
        _Privilege = o._Privilege;
        return *this;
    }
};
class user
{
private:
    BPTree<int, user_data> _Root;
    int _Cur_Id;
public:
    friend class Database;
    friend class Interactor;
    user(): _Root("_User_Data"), _Cur_Id(2018) 
    {
        std::fstream _Iofile;
        _Iofile.open("_User_Data");
    }
    int Register(const char* a, const char* b, const char* c, const char* d)
    {
        user_data u(a, b, c, d);
        _Root.insert(_Cur_Id, u);
        return _Cur_Id++;
    }
    bool login(int id, const char* name)
    {
    	auto cur = _Root.query(id);
        if(cur.second == true && cur.first._Password == name) return true;
        return false;
    }
    pair<user_data, bool> query_profile(int id)
    {
        return _Root.query(id);
    }
    bool modify_profile(int id, const char* a, const char* b, const char* c, const char* d)
    {
        user_data u(a, b, c, d, _Root.query(id).first._Privilege);
        auto cur = _Root.query(id);
        if(cur.second == false)return 0;
        _Root.modify(id, u);
        return true;
    }
    bool modify_privilege(int id1, int id2, int privilege)
    {
        user_data u(_Root.query(id2).first);
        u._Privilege = privilege;
        _Root.modify(id2, u);
        return true;
    }
};
}
