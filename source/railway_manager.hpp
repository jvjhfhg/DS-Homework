#pragma once

#include"lib/utility.hpp"
#include"User.hpp"
#include"Train.hpp"
#include"Order_user.hpp"
#include"lib/exceptions.hpp"
#include"Ticket.hpp"
#include"Order_time.hpp"
#include<fstream>
#include"lib/map.hpp"
#include<cmath>

namespace sjtu
{
class Database
{
private:
    user _User;
    train _Train;
    ticket _Ticket;
    order_user _Order_User;
    order_time _Order_Time;
    BPtree<string, string> _Station;
public:
    friend class Interactor;
    Database():_User(), _Train(), _Ticket(), _Order_User(), _Order_Time(), _Station("stations")
    {
        std::fstream _Iofile;
        _Iofile.open("stations");
        user::_Cur_Id = 2018;
        order_map::_Num_Of_File = -1;
        ticket_map::_Num_Of_File = 1;
    }
};
class Interactor
{
private:
    static Database _Data_Base;
public:
    static int Register(const char* a, const char* b, const char* c, const char* d)
    {
        return _Data_Base._User.Register(a, b, c, d);
    }
    static bool Login(int id, const char* name)
    {
        return _Data_Base._User.login(id, name);
    }
    static pair<user_data, bool> QueryProfile(int id)
    {
        return _Data_Base._User.query_profile(id);
    }
    static bool ModifyProfile(int id, const char* a, const char* b, const char* c, const char* d)
    {
        return _Data_Base._User.modify_profile(id, a, b, c, d);
    }
    static bool ModifyPrivilege(int id1, int id2, int privilege)
    {
        return _Data_Base._User.modify_privilege(id1, id2, privilege);
    }
    static bool AddTrain(const char* a,const char* b,const char* c,int d,int e,const char** f,train_station* g)
    {
        return _Data_Base._Train.add_train(a, b, c, d, e, f, g);
    }
    static pair<const char*, train_data> QueryTrain(const char* id)
    {
        return _Data_Base._Train.query_train(id);
    }
    static bool DeleteTrain(const char* id)
    {
        if(_Data_Base._Train.query_train(id).second._Published) return false;
        return _Data_Base._Train.delete_train(id);
    }
    static bool ModifyTrain(const char* a,const char* b,const char* c,int d,int e,const char** f,train_station* g)
    {
        if(_Data_Base._Train.query_train(a).second._Published) return false;
        return _Data_Base._Train.modify_train(a, b, c, d, e, f, g);
    }
    static bool SaleTrain(const char* id)
    {
        train_data d = _Data_Base._Train.query_train(id).second;
        for(int i = 0;i < d._Num_Station - 1;i++)
        {
            if(!_Data_Base._Station.query(d._Station[i]._Name).second) _Data_Base._Station.insert(d._Station[i]._Name, d._Catalog);
            for(int j = i + 1;j < d._Num_Station;j++)
            {
                ticket_key aaa(d._Station[i]._Name, d._Station[j]._Name, d._Catalog);
                pair<string, double> p[7];
                for(int l = 0;l < d._Num_Price;l++)
                {
                    p[l].first = d._Name_Price[l];
                    double money = 0;
                    for(int h = i + 1;h <= j;h++) money += d._Station[h]._Price[l];
                    p[l].second = money;
                }
                ticket_data ccc(d._Station[i]._Arrive, d._Station[j]._Arrive, d._Num_Price, p);
                string bbb(id);
                _Data_Base._Ticket.add_ticket(aaa, bbb, ccc);
            }
        }
        _Data_Base._Train.publish(id);
    }
    static int Clean()
    {
        _Data_Base._User._Root.clear();
        _Data_Base._Train._Root.clear();
        _Data_Base._Ticket._Root.clear();
        _Data_Base._Order_User._Root.clear();
        _Data_Base._Order_Time._Root.clear();
        return 1;
    }
    
    static vector<pair<pair<const char*, train_data>, pair<pair<string, ticket_data>, pair<date, date>>>>  QueryTicket(const char* loc1, const char* loc2, const char* Date, const char* catalog)
    {
        ///listnum = length of vector;
        ///if(0) return;
        vector<pair<date, date>> vpdd;
        ticket_key t(loc1, loc2, catalog);
        vector<pair<string, ticket_data>> vpstd(_Data_Base._Ticket.query_ticket(t));
        date dx(Date, catalog);
        pair<date, date> pdd(dx, dx);
        for(int j = 0;j < vpstd.size();j++) vpdd.push_back(pdd);
        {
            for(int i = 0;i < vpstd.size();i++)
            {
                ticket_data td = vpstd[i].second;
                while(td._Time_From.hour > 24)
                {
                    td._Time_From.hour -= 24;
                    vpdd[i].first.day += 1;
                }
                while(td._Time_To.hour > 24)
                {
                    td._Time_To.hour -= 24;
                    vpdd[i].second.day += 1;
                }
            }
        }
        vector<pair<pair<const char*, train_data>, pair<pair<string, ticket_data>, pair<date, date>>>> vppstpdd;
        for(int j = 0;j < vpstd.size();j++)
        {
            vppstpdd[j].second = pair<pair<string, ticket_data>, pair<date, date>>(vpstd[j], vpdd[j]);
            vppstpdd[j].first = _Data_Base._Train.query_train(vpstd[j].first._str);
        }
        return vppstpdd;
    }
    static bool BuyTicket(int id, int num, const char* train_id, const char* loc1, const char* loc2, const char* Date, const char* kind)
    {
        string c = _Data_Base._Train._Root.query(train_id).first._Catalog;
        date d(Date, c._str);
        order_map m;
        ticket_key tk(loc1, loc2, c);
        ticket_map tm = _Data_Base._Ticket._Root.query(tk).first;
        order_key ok(id, d);
        bool b = _Data_Base._Order_User._Root.query(ok).second;
        if(b)
        {
            m = _Data_Base._Order_User._Root.query(ok).first;
            ticket_order o = m._Sub_Root.query(train_id).first;
            o._Num_Of_Ticket += num;
            m._Sub_Root.modify(train_id, o);
            return 1;
        }
        else
        {
            ticket_data td = tm._Sub_Root.query(train_id).first;
            ticket_order o(loc1, loc2, td, num);
            m._Sub_Root.insert(train_id, o);
            _Data_Base._Order_User._Root.insert(ok ,m);
            return 1;
        }
    }
    static bool RefundTicket(int id, int num, const char* train_id, const char* loc1, const char* loc2, const char* Date, const char* kind)
    {
        return BuyTicket(id, -num, train_id, loc1, loc2, Date, kind);
    }
    static vector<pair<string, ticket_order>> QueryOrder(int id, date t)
    {
        ///listnum = length of vector;
        return _Data_Base._Order_User.query_order(id, t);
    }
    static pair<pair<pair<string, ticket_data>,pair<const char*, train_data>>, pair<pair<string, ticket_data>,pair<const char*, train_data>>> QueryTransfer(const char* Loc1, const char* Loc2, const char* Date, const char* Catalog)
    {
        date d(Date, Catalog);
        time mint(233333, 233333);
        pair<string, ticket_data> pst1;
        pair<const char*, train_data> pcc1;
        pair<string, ticket_data> pst2;
        pair<const char*, train_data> pcc2;
        vector<pair<string, string>> vss(_Data_Base._Station.traverse());
        for(int k = 0;k < vss.size();k++)
        {
            string Loc3 = vss[k].first;
            ticket_key tk1(Loc1, Loc3, d.catalog);
            ticket_key tk2(Loc3, Loc1, d.catalog);
            ticket_key tk3(Loc2, Loc3, d.catalog);
            ticket_key tk4(Loc3, Loc2, d.catalog);
            vector<pair<string, ticket_data>> vpstd1;
            vector<pair<string, ticket_data>> vpstd2;
            ;
            if(_Data_Base._Ticket.query_ticket(tk1).size() != 0 && _Data_Base._Ticket.query_ticket(tk3).size() != 0)
            {
                time t;
                vpstd1 = _Data_Base._Ticket.query_ticket(tk1);
                vpstd2 = _Data_Base._Ticket.query_ticket(tk3);
                for(int i = 0;i < vpstd1.size();i++)
                {
                    for(int j = 0;j < vpstd2.size();j++)
                    {
                        t.hour = abs(vpstd1[i].second._Time_To.hour - vpstd1[i].second._Time_From.hour) + abs(vpstd2[j].second._Time_To.hour - vpstd2[j].second._Time_From.hour);
                        t.minute = abs(vpstd1[i].second._Time_To.minute - vpstd1[i].second._Time_From.minute) + abs(vpstd2[j].second._Time_To.minute - vpstd2[j].second._Time_From.minute);
                        if(t < mint)
                        {
                            mint = t;
                            string id1 = _Data_Base._Ticket.query_ticket(tk1)[i].first;
                            string id3 = _Data_Base._Ticket.query_ticket(tk1)[j].first;
                            pst1 = pair<string, ticket_data>(id1 ,vpstd1[i].second);
                            pcc1 = pair<const char*, train_data>(id1._str, _Data_Base._Train.query_train(id1._str).second);
                            pst2 = pair<string, ticket_data>(id3 ,vpstd2[i].second);
                            pcc2 = pair<const char*, train_data>(id3._str, _Data_Base._Train.query_train(id3._str).second);
                        }
                    }
                }
                continue;
            }
        }
        pair<pair<string, ticket_data>,pair<const char*, train_data>> ppsp1(pst1, pcc1);
        pair<pair<string, ticket_data>,pair<const char*, train_data>> ppsp2(pst2, pcc2);
        return pair<pair<pair<string, ticket_data>,pair<const char*, train_data>>, pair<pair<string, ticket_data>,pair<const char*, train_data>>>(ppsp1, ppsp2);
    }
};

}
