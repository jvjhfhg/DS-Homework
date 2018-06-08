// This is the main source file of backend test

#include <cstdio>

#include "railway_manager.hpp"
#include "lib/algorithm.hpp"

int main() {
    char s[105];
    sjtu::string opt;

    char a[105], b[105], c[105], d[105];
    int x, y, z;

    sjtu::Interactor::Clean();

    while (~scanf("%s", s)) {
        opt = s;
        if (opt == "register") {
            scanf("%s%s%s%s", a, b, c, d);
            printf("%d\n", sjtu::Interactor::Register(a, b, c, d));
        } else if (opt == "login") {
            scanf("%d%s", &x, a);
            printf("%d\n", sjtu::Interactor::Login(x, a));
        } else if (opt == "query_profile") {
            scanf("%d", &x);
            auto res = sjtu::Interactor::QueryProfile(x);
            if (res.)
        }
    }
    
    return 0;
}
