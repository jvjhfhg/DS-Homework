# <center>焱轟票管理系统开发手册</center>

这是一个虚假的焱轟票管理系统。

~~没有做出来像12306一样的验证码真是抱歉了。~~

## 文件

| 文件名                   | 备注                                                         |
| ------------------------ | ------------------------------------------------------------ |
| `lib/algorithm.hpp`      | String类（有向std::string的类型转换）、Date类、Time类        |
| `lib/b_plus_tree.hpp`    | BPTree类                                                     |
| `lib/deque.hpp`          | deque类                                                      |
| `lib/exceptions.hpp`     | exception库（STL用）                                         |
| `lib/map.hpp`            | map类                                                        |
| `lib/priority_queue.hpp` | priority_queue类                                             |
| `lib/utility.hpp`        | pair类（有向std::pair的类型转换）                            |
| `lib/file_map.hpp`       | FileMap类，利用map类实现的简易外部查找类，用于将地名映射到int |
| `lib/vector.hpp`         | vector类                                                     |
| `place.hpp`              | Places类，将地名映射到int                                    |
| `user.hpp`               | Users类，进行用户相关的系列操作                              |
| `train.hpp`              | Trains类，进行车次相关的系列操作，提供一些票务相关操作的接口 |
| `ticket.hpp`             | Tickets类、OrderTime类、OrderUser类，进行票务相关的系列操作  |
| `railway_manager.hpp`    | 主交互库，提供向外的所有接口                                 |

## 对各文件的具体说明

#### `lib/algorithm`

-   **简述**：String类（有向std::string的类型转换）、Date类、Time类。


-   **函数**：
    -   `void swap(T a, T b)`：交换a和b。
-   **`class String`**：
    -   `int Length()`：返回String的长度。
    -   `const char *Str()`：以c_str形式返回String。
    -   `void Read()`：从终端中读入到String。
    -   `static String Float(double x)`：将一个浮点数x转换为String。
    -   `static String Int(int x)`：将一个整型数x转换为String。
    -   `int ToInt()`：将String转换为int。
    -   `double ToFloat()`：将String转换为double。
-   **`struct Time`**：

    -   **成员**：`int hour, minute`
-   **`struct Date`**：

    -   **成员**：`int year, month, day`
-   上述两者均实现了`const char *ToString()`，用于格式化输出。

#### `lib/b_plus_tree.hpp`

- **简述**：BPTree类。
- **接口**：
  - `BPTree(const char *filename)`：将这棵B+树的数据存放在filename这个文件中。
  - `bool insert(Key key, T data)`：插入新值，插入失败返回false。
  - `void erase(Key key)`：删除一个值，必须保证其存在。
  - `pair<T, bool> query(Key key)`：查找一个值，如果不存在返回T类型的随机值与false。
  - `void modify(Key key, T date)`：修改一个值，必须保证其存在。
  - `vector<pair<Key, T>> traverse()`：按key的顺序输出整棵树的数据。
  - `void clear()`：~~后端程序设计，从删库到跑路。~~

#### `lib/deque.hpp`

-   **简述**：deque类，与STL类似。

#### `lib/exceptions.hpp`

-   **简述**：exception类，主要给STL用。
-   **四种exception**：
    -   `index_out_of_bound`
    -   `runtime_error`
    -   `invalid_iterator`
    -   `container_is_empty`

#### `lib/map.hpp`

-   **简述**：map类，与STL相似。

#### `lib/file_map.hpp`

- **简述**：FileMap类，利用map类实现的简易外部查找类。
- **接口**：
  - 因为它是从`lib/fake_b_plus_tree.hpp`移植过来的，所以拥有BPTree类的所有接口。
  - `int count(Key key)`：查找一个键值是否存在。
  - `int size()`：返回树中元素个数。

#### `lib/priority_queue.hpp`

-   **简述**：priority_queue类，与STL相似。

#### `lib/utility.hpp`

-   **简述**：pair，与STL相似，在STL大作业提供的`utility.hpp`的基础上增加了比较函数的重载与向std::pair的类型转换。同时实现了make_pair。

#### `lib/vector.hpp`

- **简述**：vector类，与STL相似。

#### `place.hpp`

- **简述**：Places类，将地名映射到int（1-based）。
- **接口**：
  - `int Query(String name)`：查找name的编号，不存在返回0。
  - `String QueryName(int idx)`：查找编号为idx的地名，不存在返回空String。
  - `void Insert(String name)`：插入一个新地名name，如果存在则不进行插入。
  - `int Size()`：返回当前地名总数。
  - `void Clear()`：~~后端程序设计，从删库到跑路。~~

#### `user.hpp`

-   **简述**：Users类，实现用户相关操作。内部实现的User类为用户信息类，请不要调用。
-   **`enum User::Privilege`**：权限的枚举类，可用值有`Unregistered = 0, Normal = 1, Admin = 2`。
-   **接口**：
    -   `int Register(const char *name, const char *password, const char *email, const char *phone)`：注册一个新用户，返回id。
    -   `bool Login(int id, const char *password)`：登录用户，返回是否成功。
    -   `pair<User, bool> Query(int id)`：查询指定id用户的用户信息，失败返回随机User与false。
    -   `bool Modify(int id, const char *name, const char *password, const char *email, const char *phone)`

#### `train.hpp`

-   **简述**：车次类。

#### `ticket.hpp`

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