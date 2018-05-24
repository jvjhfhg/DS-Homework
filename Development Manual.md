# <center>焱轟票管理系统开发手册</center>

TODO



## 文件

| 文件名                   | 备注                |
| ------------------------ | ------------------- |
| `lib/algorithm.hpp`      | 常用算法库          |
| `lib/deque.hpp`          | deque类             |
| `lib/exceptions.hpp`     | 异常处理库（STL用） |
| `lib/map.hpp`            | map类               |
| `lib/priority_queue.hpp` | priority_queue类    |
| `lib/utility.hpp`        | pair类              |
| `lib/b_plus_tree.hpp`    | B+树类              |
| `user.hpp`               | 用户类              |
| `train.hpp`              | 车次类              |
| `order.hpp`              | 订单类              |
| `railway_manager.hpp`    | 主交互库            |

## 对各文件的具体说明

#### `lib/algorithm`

-   **简述**：常用算法库。


-   **函数**：
    -   `swap(a, b)`：交换a和b。

#### `lib/deque.hpp`

-   **简述**：双端队列，与STL相似。

#### `lib/exceptions.hpp`

-   **简述**：异常处理库，主要给STL用。
-   **四种exception**：
    -   `index_out_of_bound`
    -   `runtime_error`
    -   `invalid_iterator`
    -   `container_is_empty`

#### `lib/map.hpp`

-   **简述**：映射，与STL相似。

#### `lib/priority_queue.hpp`

-   **简述**：优先队列，与STL相似。

#### `lib/utility.hpp`

-   **简述**：pair，与STL相似，在STL大作业提供的`utility.hpp`的基础上增加了比较函数的重载。

#### `lib/b_plus_tree.hpp`

-   **简述**：B+树。

#### `user.hpp`

-   **简述**：用户类。

#### `train.hpp`

-   **简述**：车次类。

#### `order.hpp`

-   **简述**：订单类。

#### `railway_manager.hpp`

-   **简述**：主交互库。所有接口为`class Interactor`的静态公共成员函数。
-   **接口**：
    -   `int Register(char *username, char *password, char *email, char *phone)`：注册新用户，返回用户id。
    -   `bool Login(int userid, char *password)`：用户登录，返回是否成功登录。
    -   `User QueryProfile(int userid)`：查询用户信息，若用户不存在，返回一个**userid为-1、privilege为0 (unregistered)的用户**。
    -   `bool ModifyProfile(int userid, char *username, char *password, char *email, char *phone)`：修改用户信息，若用户不存在返回false。
    -   `bool ModifyPrivilege(int userid1, int userid2, User::UserPrivilege privilege)`：用户userid1申请将userid2的权限改为privilege，若userid1权限不够返回false。

## 代码规范

-   **命名规则**：类名、函数名、变量名取得有意义，尤其是类名及其接口等不要出现无意义的名字。具体规则

    -   所有`namespace`（除`sjtu`）、类名、类的`public`函数名、非类成员函数名全部使用Pascal命名法。

        如：`MyNamespace`, `MyClass`, `MyClass::MyPublicFunction()`

    -   所有非类`private`、`protected`变量使用驼峰命名法。

        如：`myVariable`

    -   **建议**所有类的`private`、`protected`成员（函数、变量）由单个下划线开头，后接驼峰命名法。由于`private`和`protected`的命名方式不统一一般不会造成太大影响，所以不做强制要求。

        如：`_myPrivateFunction()`, `_myPrivateVariable`

    -   全大写命名的常量用下划线分隔。

        如：`MY_CONSTANT`

-   **代码风格**：操作符两侧是否有空格、大括号换行与否等不做要求，但请使代码可读性尽量高。

-   **注释**：由于有开发文档描述具体的接口，所以留一些方便自己维护和相互查错的注释就可以了。

-   **只允许在自己的函数中使用`using`及`using namespace`语句，禁止在头文件中全局使用。**