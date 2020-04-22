#include "../../source/railway_manager.hpp"

using namespace System;
using namespace System::Collections::Generic;

namespace RailwayManager_DS_2018Spring {
    public enum class UserPrivilege {
        Unregistered = 0,
        Normal = 1,
        Admin = 2
    };

    public ref class User {
    public:
        String ^name, ^password, ^email, ^phone;
        int id;
        UserPrivilege ^priv;

    public:
        User(): name(""), password(""), email(""), phone(""), id(-1), priv(UserPrivilege::Unregistered) {}
        User(String ^_name, String ^_password, String ^_email, String ^_phone, int _id, UserPrivilege ^_priv):
            name(_name), password(_password), email(_email), phone(_phone), id(_id), priv(_priv) {}
    };

    const char *ToCStr(System::String ^s) {
        return (char *)(void *)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(s);
    }

    public ref class Database {
    public:
        /* 
         * User related
         */

        static bool Login(int userid, System::String ^password) {
            const char *_password = ToCStr(password);
            return sjtu::Interactor::Login(userid, _password);
        }

        static int Register(System::String ^name, System::String ^password, System::String ^email, System::String ^phone) {
            const char *_name = ToCStr(name);
            const char *_password = ToCStr(password);
            const char *_email = ToCStr(email);
            const char *_phone = ToCStr(phone);
            return sjtu::Interactor::Register(_name, _password, _email, _phone);
        }

        static User ^QueryProfile(int userid) {
            auto user = sjtu::Interactor::QueryProfile(userid);
            if (user[0].Length() == 1 && user[0][0] == '0') return gcnew User();
            return gcnew User(gcnew String(user[0].Str()), 
                              gcnew String(""), 
                              gcnew String(user[1].Str()), 
                              gcnew String(user[2].Str()), 
                              userid, 
                              UserPrivilege(user[3].ToInt()));
        }

        static bool ModifyPrifile(int id, String ^name, String ^password, String ^email, String ^phone) {
            const char *_name = ToCStr(name);
            const char *_password = ToCStr(password);
            const char *_email = ToCStr(email);
            const char *_phone = ToCStr(phone);
            return sjtu::Interactor::ModifyProfile(id, _name, _password, _email, _phone);
        }

        static bool ModifyPrivilege(int id1, int id2, int priv) {
            return sjtu::Interactor::ModifyPrivilege(id1, id2, priv);
        }

        /* 
         * Ticket related
         */

        static List<List<String ^> ^> ^QueryTicket(String ^loc1, String ^loc2, String ^date, String ^catalogs) {
            const char *_loc1 = ToCStr(loc1);
            const char *_loc2 = ToCStr(loc2);
            const char *_date = ToCStr(date);
            const char *_catalogs = ToCStr(catalogs);
            auto tmp = sjtu::Interactor::QueryTicket(_loc1, _loc2, _date, _catalogs);
            List<List<String ^> ^> ^res = gcnew List<List<String ^> ^>(0);
            for (int i = 0; i < (int)tmp.size(); ++i) {
                List<String ^> ^vec = gcnew List<String ^>(0);
                for (int j = 0; j < (int)tmp[i].size(); ++j)
                    vec->Add(gcnew String(tmp[i][j].Str()));
                res->Add(vec);
            }
            return res;
        }

        static List<List<String ^> ^> ^QueryTransfer(String ^loc1, String ^loc2, String ^date, String ^catalogs) {
            const char *_loc1 = ToCStr(loc1);
            const char *_loc2 = ToCStr(loc2);
            const char *_date = ToCStr(date);
            const char *_catalogs = ToCStr(catalogs);
            auto tmp = sjtu::Interactor::QueryTransfer(_loc1, _loc2, _date, _catalogs);
            List<List<String ^> ^> ^res = gcnew List<List<String ^> ^>(0);
            List<String ^> ^vec = gcnew List<String ^>(0);
            for (int i = 0; i < (int)tmp.first.size(); ++i)
                vec->Add(gcnew String(tmp.first[i].Str()));
            res->Add(vec);
            vec = gcnew List<String ^>(0);
            for (int i = 0; i < (int)tmp.second.size(); ++i)
                vec->Add(gcnew String(tmp.second[i].Str()));
            res->Add(vec);
            return res;
        }

        static bool BuyTicket(int id, int num, String ^tid, String ^loc1, String ^loc2, String ^date, String ^ticketKind) {
            const char *_tid = ToCStr(tid);
            const char *_loc1 = ToCStr(loc1);
            const char *_loc2 = ToCStr(loc2);
            const char *_date = ToCStr(date);
            const char *_ticketKind = ToCStr(ticketKind);
            return sjtu::Interactor::BuyTicket(id, num, _tid, _loc1, _loc2, _date, _ticketKind);
        }

        static List<List<String ^> ^> ^QueryOrder(int id, String ^date, String ^catalogs) {
            const char *_date = ToCStr(date);
            const char *_catalogs = ToCStr(catalogs);
            auto tmp = sjtu::Interactor::QueryOrder(id, _date, _catalogs);
            List<List<String ^> ^> ^res = gcnew List<List<String ^> ^>(0);
            for (int i = 0; i < (int)tmp.size(); ++i) {
                List<String ^> ^vec = gcnew List<String ^>(0);
                for (int j = 0; j < (int)tmp[i].size(); ++j)
                    vec->Add(gcnew String(tmp[i][j].Str()));
                res->Add(vec);
            }
            return res;
        }

        static bool RefundTicket(int id, int num, String ^tid, String ^loc1, String ^loc2, String ^date, String ^ticketKind) {
            const char *_tid = ToCStr(tid);
            const char *_loc1 = ToCStr(loc1);
            const char *_loc2 = ToCStr(loc2);
            const char *_date = ToCStr(date);
            const char *_ticketKind = ToCStr(ticketKind);
            return sjtu::Interactor::RefundTicket(id, num, _tid, _loc1, _loc2, _date, _ticketKind);
        }

        /*
        * Train related
        */

        static bool AddTrain(List<String ^> ^commands) {
            sjtu::vector<sjtu::String> _commands;
            for (int i = 0; i < (int)commands->Count; ++i) {
                _commands.push_back(ToCStr(commands[i]));
            }
            return sjtu::Interactor::AddTrain(_commands);
        }

        static bool SaleTrain(String ^tid) {
            return sjtu::Interactor::SaleTrain(ToCStr(tid));
        }

        static List<List<String ^> ^> ^QueryTrain(String ^tid) {
            List<List<String ^> ^> ^res = gcnew List<List<String ^> ^>(0);
            auto tmp = sjtu::Interactor::QueryTrain(ToCStr(tid));
            for (int i = 0; i < (int)tmp.size(); ++i) {
                List<String ^> ^vec = gcnew List<String ^>(0);
                for (int j = 0; j < (int)tmp[i].size(); ++j)
                    vec->Add(gcnew String(tmp[i][j].Str()));
                res->Add(vec);
            }
            return res;
        }

        static bool DeleteTrain(String ^tid) {
            return sjtu::Interactor::DeleteTrain(ToCStr(tid));
        }

        static bool ModifyTrain(List<String ^> ^commands) {
            sjtu::vector<sjtu::String> _commands;
            for (int i = 0; i < (int)commands->Count; ++i) {
                _commands.push_back(ToCStr(commands[i]));
            }
            return sjtu::Interactor::ModifyTrain(_commands);
        }

        /*
        * System related
        */

        static void Clean() {
            sjtu::Interactor::Clean();
        }
    };
}