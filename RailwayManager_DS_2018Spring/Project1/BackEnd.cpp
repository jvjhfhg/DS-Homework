#include "../../source/back_end_main.hpp"

typedef System::String ^ String;

namespace sjtu {
    public ref class User {
    public:
        static bool Login(String username, String password) {
            if (username != "jvjhfhg" || password != "jvjhfhg")
                return false;
            // TODO
            return true;
        }

        static bool Register() {
            return true;
        }
    };
}