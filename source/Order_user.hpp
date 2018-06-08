#pragma once
#include<fstream>
#include<cstring>
#include<iostream>
#include"lib/BPtree.hpp"
#include<cstdio>
#include"lib/algorithm.hpp"
#include"ticket.hpp"
#include"lib/vector.hpp"
#include"lib/utility.hpp"
namespace sjtu
{
class order_key
{
private:
    int _User_Id;
    date _Date;
public:
    order_key(int a = 0, date d = date()): _User_Id(a), _Date(d) {}
    bool operator < (const order_key &o)const
    {
        if(_User_Id < o._User_Id) return true;
        if(_User_Id > o._User_Id) return false;
        if(_Date < o._Date) return true;
        return false;
    }
    bool operator = (const order_key &o)const
    {
        if(_User_Id == o._User_Id && _Date == o._Date) return true;
        return false;
    }
    bool operator == (const order_key &o)const
    {
        if(_User_Id == o._User_Id && _Date == o._Date) return true;
        return false;
    }
};

class ticket_order
{
private:
    int _Num_Of_Ticket;
    string _Loc1;
    string _Loc2;
    ticket_data _Other_Data;
public:
    friend class Interactor;
    ticket_order() = default;
    ticket_order(const char* a, const char* b, ticket_data c, int i):_Loc1(a), _Loc2(b), _Other_Data(c), _Num_Of_Ticket(i) {}
};

class order_map
{
private:
    BPtree<string, ticket_order> _Sub_Root;
    static int _Num_Of_File;
public:
    friend class order_user;
    friend class Database;
    friend class Interactor;
    order_map():_Sub_Root("Fuck you!")
    {
        char* str;
        sprintf(str, "%d", _Num_Of_File);
        const char* cstr(str);
        std::fstream _Iofile;
        _Iofile.open(cstr);
        _Sub_Root.file = cstr;
        _Num_Of_File--;
    }
};

class order_user
{
private:
    BPtree<order_key, order_map> _Root;
public:
    friend class Interactor;
    order_user():_Root("_Order_User")
    {
        std::fstream _Iofile;
        _Iofile.open("_Order_User");

    }
    vector<pair<string, ticket_order>> query_order(int id, date t)
    {
        order_key k(id, t);
        order_map m = _Root.query(k).first;
        return m._Sub_Root.traverse();
    }
};
}

