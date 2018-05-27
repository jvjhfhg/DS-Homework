#define DEBUG

#ifndef DEBUG
# include "../../source/railway_manager.hpp"
#endif

#include <vector>

namespace RailwayManager_DS_2018Spring {
    public enum class UserPrivilege{
        unregistered = 0,
        user = 1,
        admin = 2
    };

    public ref class User {
    public:
        System::String ^username, ^password, ^email, ^phone;
        int id;
        UserPrivilege ^priv;

    public:
        User(): username(""), password(""), email(""), phone(""), id(-1), priv(UserPrivilege::unregistered) {}
        User(System::String ^_username, System::String ^_password, System::String ^_email, System::String ^_phone, int _id, UserPrivilege ^_priv):
            username(_username), password(_password), email(_email), phone(_phone), id(_id), priv(_priv) {}
    };

    public ref class Database {
    public:
        static bool Login(int userid, System::String ^password) {
#ifdef DEBUG
            if (userid != 2018 || password != "jvjhfhg")
                return false;
            return true;
#else
            char *_password = (char *)(void *)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(password);
            return sjtu::Interactor::Login(userid, _password);
#endif
        }

        static int Register(System::String ^username, System::String ^password, System::String ^email, System::String ^phone) {
#ifdef DEBUG
            return 2018;
#else
            char *_username = (char *)(void *)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(username),
                 *_password = (char *)(void *)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(password),
                 *_email = (char *)(void *)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(email),
                 *_phone = (char *)(void *)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(phone);
            return sjtu::Interactor::Register(_username, _password, _email, _phone);
#endif
        }

        static User ^QueryProfile(int userid) {
#ifdef DEBUG
            return gcnew User("jvjhfhg", "jvjhfhg", "jvjhfhg@126.com", "+86-12306", 2018, UserPrivilege::admin);
#else
            auto user = sjtu::Interactor::QueryProfile(userid);
            return User(user.username, user.password, user.email, user.phone, user.id, user.privilege);
#endif
        }

        static System::Collections::Generic::List<int> ^Vector() {
            std::vector<int> vec;
            for (int i = 0; i < 100; ++i)
                vec.push_back(i);
            System::Collections::Generic::List<int> ^res = gcnew System::Collections::Generic::List<int>((int)vec.size());
            for (int i: vec)
                res->Add(i);
            return res;
        }
    };
}