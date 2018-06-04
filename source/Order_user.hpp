#pragma once
#include<fstream>
#include<cstring>
#include<iostream>
#include<bptree.cpp>
#include<cstdio>
#include"lib_utility.hpp"
#include"ticket.hpp"
#include"vector.hpp"

class order_key
{
private:
    int _User_Id;
    date _Date;
public:
    order_key(int a, date d): _User_Id(a), _Date(d) {}
};

class ticket_order
{
private:
    int _Num_Of_Ticket;
    string _Loc1;
    string _Loc2;
    ticket_data _Other_Data;
public:
    ticket_order(const char* a, const char* b, ticket_data c, int i):_Loc1(a), _Loc2(b), _Other_data(c), _Num_Of_Ticket(i) {}
};

class order_map
{
private:
    BPtree<string, ticket_order> _Sub_Root;
    static int _Num_Of_File;
public:
    order_map()
    {
        char* str;
        sprintf(str, _Num_Of_File);
        const char* cstr(str);
        fstream _Iofile;
        _Iofile.open(cstr);
        _Sub_Root = BPtree<string, ticket_order> (cstr);
        _Num_Of_File--;
    }
};

class order_user
{
private:
    BPtree<order_key, order_map> _Root;
public:
    order_user()
    {
        fstream _Iofile;
        _Iofile,open("_Order_User");
        _Root = BPtree<order_key, order_map> ("_Order_User");
    }
    vector<pair<string, ticket_order>> query_order(int id, date t)
    {
        order_key k(id, t);
        order_map m = _Root.query(k);
        return m._Sub_Root.traverse();
    }
};


