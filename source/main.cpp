// This is the main source file of backend test

#include <cstdio>
#include <cstring>

#include "railway_manager.hpp"
#include "lib/algorithm.hpp"

sjtu::Interactor _Interactor;
int main() {
    char s[105];

    char a[105], b[105], c[105], d[105];
    int x, y, z;

    _Interactor.Clean();

    while (~scanf("%s", s)) {
    	sjtu::string opt(s);
        if (opt == "register") {
            scanf("%s%s%s%s", a, b, c, d);
            printf("%d\n", _Interactor.Register(a, b, c, d));
        }
		else if (opt == "login") {
            scanf("%d%s", &x, a);
            printf("%d\n", _Interactor.Login(x, a));
        }
		else if (opt == "query_profile") {
            scanf("%d", &x);
            auto res = _Interactor.QueryProfile(x);
            if (res.second == false) puts("0");
            else printf("%s %s %s %d\n", res.first._User_Name.c_str(), res.first._Email.c_str(), res.first._Phone.c_str(), res.first._Privilege);
        }
		else if (opt == "modify_profile") {
            scanf("%d%s%s%s%s", &x, a, b, c, d);
            printf("%d\n", _Interactor.ModifyProfile(x, a, b, c, d));
        }
		else if (opt == "modify_privilege") {
            scanf("%d%d%d", &x, &y, &z);
            if (z < 1 || z > 2) puts("0");
            else printf("%d\n", _Interactor.ModifyPrivilege(x, y, z));
        }
		else if (opt == "query_ticket") {
            scanf("%s%s%s%s", a, b, c, d);
            auto res = _Interactor.QueryTicket(a, b, c, d);
            if ((int)res.size() == 0) {
                puts("-1");
                continue;
            }
            printf("%d\n", (int)res.size());
            for (int i = 0 ; i < res.size() ; i++) 
				for(int j = 0 ; j < res[i].size() ; j++){
             	   printf("%s%c", res[i][j].c_str(),j + 1 == res[i].size() ? '\n' : ' ');
            	}
        }
		else if (opt == "query_transfer") {
            scanf("%s%s%s%s", a, b, c, d);
            auto res = _Interactor.QueryTransfer(a, b, c, d);
            if ((int)res.size() == 0) {
                puts("-1");
                continue;
            }
            printf("%d\n", (int)res.size());
            for (int i = 0 ; i < res.size() ; i++) 
				for(int j = 0 ; j < res[i].size() ; j++){
             	   printf("%s%c", res[i][j].c_str(),j + 1 == res[i].size() ? '\n' : ' ');
            	}
        }
        
        else if (opt == "clean") {
        	printf("%d\n" , _Interactor.Clean());
		}
        else if (opt == "exit") {
        	puts("BYE");
		}
    }
    
    return 0;
}
