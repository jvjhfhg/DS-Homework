#ifndef "Train.hpp"
#define "Train.hpp"
#include<fstream>
#include<iostream>
#include<bptree.cpp>
#include"lib_utility.hpp"
#include"Ticket.hpp"

class train_station
{
public:
    string _Name;
    time _Arrive;
    time _Start;
    time _Stopover;
    double _Price[7];

    train_station(const char* a, time b, time c, time d, double* e): _Name(a), _Arrive(b), _start(c), _Stopover(d), _Price(e){}
};

class train_data
{
private:
    string _Name;
    string _Catalog;
    int _Num_Station;
    int _Num_Price;
    string _Name_Price[7];
    train_station _Station[65];
public:
    train_data(const char* b,const char* c,int d,int e,const char** f,train_station* g)
    :,_Name(b),_Catalog(c),_Num_Station(d),_Num_Price(e);
    {
        for(int i = 0;i < _Num_Price;i++) _Name_Price[i] = f[i];
        for(int i = 0;i < _Num_Station;i++) _Station[i] = g[i];
    }
    train_data(const train_data& o)
    {
        _Name = o._Name;
        _Catalog = o._Catalog;
        _Num_Station = o._Num_Station;
        _Num_Price = o._Num_Price;
        for(int i = 0;i < _Num_Price;i++) _Name_Price[i] = o._Name_Price[i];
        for(int i = 0;i < _Num_Station;i++) _Station[i] = o._Station[i];
    }
    train_data& operator =(const train_data& o)
    {
        _Name = o._Name;
        _Catalog = o._Catalog;
        _Num_Station = o._Num_Station;
        _Num_Price = o._Num_Price;
        for(int i = 0;i < _Num_Price;i++) _Name_Price[i] = o._Name_Price[i];
        for(int i = 0;i < _Num_Station;i++) _Station[i] = o._Station[i];
        return *this;
    }
};

class train;
{
private:
    BPtree<string, train_data> _Root;
public:
    train()
    {
        fstream _Iofile;
        _Iofile.open("_Train_Data");
        _Root = Bptree<int, user_data>("_Train_Data");
    }
    bool add_train(const char* a,const char* b,const char* c,int d,int e,const char** f,train_station* g)
    {
        train_data t(b, c, d, e, f, g);
        _Root.insert(a, t);
        return true;
    }
    pair<char*, train_data> query_train(const char* id)
    {
        ///if(!_Root.query(id).second) return 0;
        pair<char*, train_data> p;
        p.first = id;
        p.second = _Root.query(id).first;
        return p;
    }
    bool delete_train(const char* id)
    {
        _Root.erase(id);
        return true;
    }
    bool modify_train(const char* a,const char* b,const char* c,int d,int e,const char** f,train_station* g)
    {
        train_data t(b, c, d, e, f);
        _Root.modify(id, t);
        return true;
    }
};


#endif
