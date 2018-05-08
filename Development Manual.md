# <center>焱轟票管理系统开发手册</center>

TODO



## 工具模板类

### String

-   ​



## 数据类

### User

-   成员：`Name, Password, Email, Phone, ID, Privilege`
    -   `Name & Password & Email & Phone`：String
    -   `ID`：unsigned int
    -   `Privilege`：`enum Privilege {user = 1, admin = 2}`
-   接口：
    -   Constructor