#pragma once
#include<fstream>
#include<cstring>
#include<iostream>
#include<bptree.cpp>
#include<cstdio>
#include"lib_utility.hpp"
class remain_data
{
private:
    string _Train_Id;
    string _Loc1;
    string _Loc2;
    date _Date;
public:
    remain_data(const char* a, const char* b, const char* c, date d): _Train_Id(a), _Loc1(b), _Loc2(c), _Date(d){}
};

class order_time
{
private:
    BPtree<remain_data, int> _Root;
public:
    order_time()
    {
        fstream _Iofile;
        Iofile.open("_Order_Time");
        _Root = BPtree<remain_data, int>("_Order_Time");
    }
    int query_remain(remain_data r)
    {
        return _Root.query(r).second;
    }
};

