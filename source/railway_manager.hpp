#pragma once

#include"lib/utility.hpp"
#include"User.hpp"
#include"Train.hpp"
#include"Order_user.hpp"
#include"lib_exceptions.hpp"
#include"Ticket.hpp"
#include"Order_time.hpp"
#include<fstream>



namespace sjtu
{
class Interactor
{
private:
    user _User;
    train _Train;
    ticket _Ticket;
    order_user _Order_User;
    order_time _Order_Time;
public:
    Interactor():_User(), _Train(), _Ticket(), _Order_User(), _Order_Time()
    {
        user::_Cur_Id = 2018;
        ticket_map::_Num_Of_File = 1;
        order_map::_Num_Of_File = -1;
    }
    static int Register(const char* a, const char* b, const char* c, const char* d)
    {
        return _User.Register(a, b, c, d);
    }
    static bool Login(int id, const char* name)
    {
        return _User.login(id, name);
    }
    static user_data QueryProfile(int id)
    {
        return _User.query_profile(id);
    }
    static bool ModifyProfile(int id, const char* a, const char* b, const char* c, const char* d)
    {
        return _User.modify_profile(id, a, b, c, d);
    }
    static bool ModifyPrivilege(int id1, int id2, int privilege)
    {
        return _User.modify_privilege(id1, id2, privilege);
    }
    static bool AddTrain(const char* a,const char* b,const char* c,int d,int e,const char** f,train_station* g)
    {
        return _Train.add_train(a, b, c, d, e, f, g);
    }
    static pair<char*, train_data> QueryTrain(const char* id)
    {
        return _Train.query_train(id);
    }
    static bool DeleteTrain(const char* id)
    {
        return _Train.delete_train(id);
    }
    static bool ModifyTrain(const char* a,const char* b,const char* c,int d,int e,const char** f,train_station* g)
    {
        return _Train.modify_train(a, b, c, d, e, f, g);
    }
    static bool SaleTrain(const char* id)
    {
        train_data d = _Train.query_train(id).second;
        for(int k = 1,k <= 30;k++)
        {
            date day(2018, 6, k, d._Catalog);
            for(int i = 0;i < d._Num_Station - 1;i++)
            {
                for(int j = i + 1;j < d._Num_Station;j++)
                {
                    ticket_key aaa(d._Station[i]._Name, d.Station[j]._Name, day);
                    pair<string, double> p[7];
                    for(int l = 0;l < d._Num_Price;l++)
                    {
                        p[l].first = d.Name_Price[l];
                        double money = 0;
                        for(int h = i + 1;h <= j;h++) money += d.Station[h]._Price[l];
                        p[l].second = money;
                    }
                    ticket_data ccc(d._Station[i]._Arrive, day, d._Station[j]._Arrive, d._Num_Price, p);
                    string bbb(id);
                    _Ticket.add_ticket(aaa, bbb, ccc);
                }
            }
        }
        DeleteTrain(id);
    }
    static int clean()
    {
        _User._Root.clear();
        _Train._Root.clear();
        _Ticket._Root.clear();
        _Order_User._Root.clear();
        _Order_Time._Root.clear();
        return 1;
    }
    static vector<pair<string, ticket_data>> QueryTicket(const char* loc1, const char* loc2, const char* Date, const char* catalog)
    {
        ///listnum = length of vector;
        ///if(0) return;
        date d(Date, catalog)
        ticket_key t(loc1, loc2, d);
        return _Ticket.query_ticket(t);
    }
    static bool BuyTicket(int id, int num, const char* train_id, const char* loc1, const char* loc2, const char* Date, const char* kind)
    {
        string c = _Train._Root.query(id).second._Catalog;
        date d(Date, c);
        order_key ok(id, d);
        bool b = _Order_User._Root.query(ok).second;
        if(b)
        {
            order_map m = _Order_User._Root.query(ok).first;
            ticket_order o = m.query(train_id).first;
            o._Num_Of_Ticket += num;
            m._Sub_Root.modify(train_id, o);
            return 1;
        }
        else
        {
            order_map m;
            ticket_key tk(loc1, loc2, d);
            ticket_map tm = _Ticket._Root.query(tk).first;
            ticket_data td = tm._Sub_Root.query(train_id).first;
            ticket_order o(loc1, loc2, td, num);
            m._Sub_Root.insert(train_id, o);
            _Order_User._Root.insert(ok ,m);
            return 1;
        }
    }
    static bool RefundTicket(int id, int num, const char* train_id, const char* loc1, const char* loc2, const char* Date, const char* kind)
    {
        return BuyTicket(id, -num, train_id, loc1, loc2, Date, kind);
    }
    static vector<pair<string, ticket_order>> query_order(int id, date t)
    {
        ///listnum = length of vector;
        return _Order_User.query_order(id, t);
    }
};

}
