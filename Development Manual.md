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
| `train.hpp`              | Trains类，进行车次相关的系列操作                             |
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
    -   `bool Modify(int id, const char *name, const char *password, const char *email, const char *phone)`：修改指定id用户的用户信息，如果用户不存在返回false。
    -   `bool ModifyPrivilege(int id1, int id2, User::Privilege priv)`：用户id1尝试将用户id2的权限改为priv，返回是否成功。
    -   `void clear()`：~~后端程序设计，从删库到跑路。~~

#### `train.hpp`

-   **简述**：Trains类，实现车次相关操作。内部实现的Station类和Train类分别为车站类和车次类，请不要调用。
-   **`enum Train::Status`**：车次发布状态的枚举类，可用值有`Private = 0, Public = 1`。
-   **接口**：
    -   `bool Insert(String tid, String name, char catalog, int stationCnt, int ticKindCnt, String *tickets, Station *stations)`：添加一个新车次，其train_id为tid，返回是否成功。
    -   `bool Sale(String tid)`：发布train_id为tid的车次，返回是否成功。
    -   `pair<Train, bool> Query(String tid)`：查询train_id为tid的车次，返回这个车次的信息，若不存在返回随机Train与false。
    -   `bool Delete(String tid)`：删除train_id为tid的车次，返回是否成功。
    -   `bool Modify(String tid, String name, char catalog, int stationCnt, int ticKindCnt, String *tickets, Station *stations)`：修改train_id为tid的车次的信息，如果车次不存在返回false。
    -   `void Clear()`：~~后端程序设计，从删库到跑路。~~

#### `ticket.hpp`

-   **简述**：Tickets类、OrderTime类和OrderUser类，实现票务相关操作。内部实现的数个Key类请不要调用。
-   **`class Tickets`**：用于查询A地到B地的车次。
    -   `pair<vector<String>, bool> Query(int loc1, int loc2, char catalog)`：返回loc1到loc2的catalog类列车的所有车次的train_id。如果查询不到返回空vector和false。
    -   `void Insert(int loc1, int loc2, char catalog, String tid)`：对于loc1到loc2的catalog类列车，添加一个train_id为tid的车次。
    -   `void Clear()`：~~后端程序设计，从删库到跑路。~~
-   **`class OrderTime`**：用于查询某个车次在某日在某两站之间卖出了多少张火车票。
    -   `void Add(String tid, int ticKind, int stationIdx, Date date, int ticCnt)`：train_id为tid的火车在date这一天卖出了第stationIdx-1到第stationIdx个站之间的ticKind类票ticCnt张。
    -   `int Query(String tid, int ticKind, Date date)`：查询train_id为tid的火车在date这一天在第stationIdx-1到stationIdx个站之间卖出了多少张ticKind类票。
    -   `void Clear()`：~~后端程序设计，从删库到跑路。~~
-   **`class OrderUser`**：用于查询用户的购票信息。
    -   `vector<pair<String, Order>> Query(int id, Date date, char catalog)`：查询指定id的用户在date这一天购买的所有catalog类车次的车票。返回值中String为train_id，Order为一个包含`loc1, date1, time1, loc2, date2, time2, cnt[5]`的结构体，cnt表示每种车票的购买量。
    -   `const int *QueryActualTicket(int id, String tid, Date date, char catalog, int loc1, int loc2)`：查询指定id的用户在date这天购买的train_id为tid的车次从loc1到loc2的所有种类车票的张数，其中这辆列车的类别为catalog。
    -   `void Add(int id, String tid, char catalog, int loc1, Date date1, Time time1, int loc2, Date date2, Time time2, int *cnt)`：添加一个用户的购票/退票请求，其中购票数的变化在cnt[]中。
    -   `void Clear()`：~~后端程序设计，从删库到跑路。~~

#### `railway_manager.hpp`

-   **简述**：主交互库。所有接口为`class Interactor`的静态公共成员函数。
-   **接口**：与作业要求中的所有命令相似，只是将命名方式转为Pascal命名法。需要一行输出许多信息的，返回值类型均为`vector<String>`；需要多行输出许多信息的，返回值类型均为`vector<vector<String>>`。
    -   `void Clear()`：~~后端程序设计，从删库到跑路。~~
        -   ~~我就是要单独写这个，怎么样。~~

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