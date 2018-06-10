#pragma once
#include<fstream>
#include<iostream>
#include"lib/b_plus_tree.hpp"
#include"lib/algorithm.hpp"
#include"Ticket.hpp"
#include"lib/utility.hpp"
namespace sjtu
{
class train_station
{
public:
    string _Name;
    time _Arrive;
    time _Start;
    time _Stopover;
    double _Price[7];
    train_station(const char* a = "", time b = time(), time c = time(), time d = time(), double* e = nullptr): _Name(a), _Arrive(b), _Start(c), _Stopover(d)
    {
        if(e != NULL)for(int i = 0;i <7;i++) _Price[i] = e[i];
    }
};

class train_data
{
private:
    bool _Published;
    string _Name;
    string _Catalog;
    int _Num_Station;
    int _Num_Price;
    string _Name_Price[7];
    train_station _Station[65];
public:
    friend class Interactor;
    friend class train;
    train_data() = default;
    train_data(const char* b,const char* c,int d,int e,const char** f,train_station* g)
    :_Name(b), _Catalog(c), _Num_Station(d), _Num_Price(e), _Published(false)
    {
        for(int i = 0;i < _Num_Price;i++) _Name_Price[i] = f[i];
        for(int i = 0;i < _Num_Station;i++)
        {
            time tmp(0, 0);
            int dlt = 0;
            _Station[i]._Name = g[i]._Name;
            _Station[i]._Arrive = g[i]._Arrive + dlt;
            _Station[i]._Start = g[i]._Start + dlt;
            _Station[i]._Stopover = g[i]._Stopover;
            if(_Station[i]._Arrive < tmp)
            {
                dlt += 24;
                _Station[i]._Arrive += dlt;
                _Station[i]._Start += dlt;
            }
            else if(_Station[i]._Start < tmp)
            {
                dlt += 24;
                _Station[i]._Start += dlt;
            }
            tmp = _Station[i]._Start;
        }

    }
    train_data(const train_data& o)
    {
        _Name = o._Name;
        _Catalog = o._Catalog;
        _Num_Station = o._Num_Station;
        _Num_Price = o._Num_Price;
        _Published = o._Published;
        for(int i = 0;i < _Num_Price;i++) _Name_Price[i] = o._Name_Price[i];
        for(int i = 0;i < _Num_Station;i++) _Station[i] = o._Station[i];
    }
    train_data& operator =(const train_data& o)
    {
        if (this == &o) return *this;
        _Name = o._Name;
        _Catalog = o._Catalog;
        _Num_Station = o._Num_Station;
        _Num_Price = o._Num_Price;
        _Published = o._Published;
        for(int i = 0;i < _Num_Price;i++) _Name_Price[i] = o._Name_Price[i];
        for(int i = 0;i < _Num_Station;i++) _Station[i] = o._Station[i];
        return *this;
    }
};

class train
{
private:
    BPTree<string, train_data> _Root;
public:
    friend class Interactor;
    train():_Root("_Train_Data")
    {
        std::fstream _Iofile;
        _Iofile.open("_Train_Data");
    }
    bool add_train(const char* a,const char* b,const char* c,int d,int e,const char** f,train_station* g)
    {
        train_data t(b, c, d, e, f, g);
        string s(a);
        _Root.insert(s, t);
        return true;
    }
    pair<const char*, train_data> query_train(const char* id)
    {
        return pair<const char *, train_data>(id, _Root.query(id).first);
        ///if(!_Root.query(id).second) return 0;
        //pair<const char*, train_data> p;
        //p.first = id;
        //p.second = _Root.query(id).first;
        //return p;
    }
    bool delete_train(const char* id)
    {
        string is(id);
        _Root.erase(is);
        return true;
    }
    bool modify_train(const char* a,const char* b,const char* c,int d,int e,const char** f,train_station* g)
    {
        train_data t(b, c, d, e, f, g);
        _Root.modify(a, t);
        return true;
    }
    void publish(string id)
    {
        train_data td = _Root.query(id).first;
        td._Published = true;
        _Root.modify(id, td);
    }
};
}

