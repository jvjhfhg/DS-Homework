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
    static bool SellTrain(const char* id)
    {
        date
        DeleteTrain(id);
    }
};

}
