# <center>焱轟票管理系统开发手册</center>

TODO



## 文件

| 文件名             | 备注 |
| ------------------ | ---- |
| /lib/algorithm.hpp |      |
| /lib/              |      |
|                    |      |
|                    |      |
|                    |      |
|                    |      |
|                    |      |
|                    |      |
|                    |      |



## 工具模板类

### String类（string）

### B+树（BPlusTree）




## 数据类

### User

-   成员：`ID, Name, Password, Email, Phone, Privilege, Bought`
    -   `ID`：unsigned int
    -   Name & Password & Email & Phone`：String
    -   `Privilege`：`enum Privilege {user = 1, admin = 2}`
    -   ​
-   接口：
    -   Constructor