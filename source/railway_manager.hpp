#pragma once

#include "lib/utility.hpp"
// #include "lib/vector.hpp"

namespace sjtu {
    class Interactor {
    public:
        static int Register(const char *username, const char *password, const char *email, const char *phone) {

        }

        static int GetID(const char *username) {

        }

        static bool Login(int id, const char *password) {

        }

        static pair<User, bool> QueryProfile(int id) {

        }

        static bool ModifyProfile(int id, const char *username, const char *password, const char *email, const char *phone) {

        }

        enum UserPrivilege { user = 1, admin = 2 };

        static bool ModifyPrivilege(int id1, int id2, UserPrivilege privilege) {

        }

        /* static vector<Ticket> QueryTicket(const char *loc1, const char *loc2, const char *date, const char *catalog) {

        } */

        /* static Ticket QueryTransfer(const char *loc1, const char *loc2, const char *date, const char *catalog) {

        } */

        /* static bool BuyTicket(int id, unsigned num, const char *train_id,
                              const char *loc1, const char *loc2, const char *date, const char *catalog) {

        } */

        /* QueryOrder */

        /* RefundTicket */

        static bool AddTrain(const char *trainId, const char *trainName, )
    };
}