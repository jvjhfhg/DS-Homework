#pragma once
#include<fstream>
#include<cstring>
#include<iostream>
#include"lib/BPtree.hpp"
#include<cstdio>
#include"lib/algorithm.hpp"
#include"lib/utility.hpp"
namespace sjtu
{
class remain_data
{
private:
    string _Train_Id;
    string _Loc1;
    string _Loc2;
    date _Date;
public:
    remain_data(const char* a, const char* b, const char* c, date d): _Train_Id(a), _Loc1(b), _Loc2(c), _Date(d){}
    bool operator <(const remain_data &o)
    {
        if(_Train_Id < o._Train_Id) return true;
        if(_Train_Id > o._Train_Id) return false;
        if(_Loc1 < o._Loc1) return true;
        if(_Loc1 > o._Loc1) return false;
        if(_Loc2 < o._Loc2) return true;
        if(_Loc2 > o._Loc2) return false;
        if(_Date < o._Date) return true;
        return false;
    }
};

class order_time
{
private:
    BPtree<remain_data, int> _Root;
public:
    friend class Interactor;
    order_time():_Root("_Order_Time")
    {
        std::fstream _Iofile;
        _Iofile.open("_Order_Time");
    }
    int query_remain(remain_data r)
    {
        return _Root.query(r).second;
    }
};
}
