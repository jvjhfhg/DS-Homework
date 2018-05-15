# <center>焱轟票管理系统开发手册</center>

TODO



## 文件

| 文件名               | 备注       |
| -------------------- | ---------- |
| lib/algorithm.hpp    | 常用算法库 |
| lib/b_plus_tree.hpp  | B+树       |
| lib/file_manager.hpp | 文件操作库 |
| user.hpp             | 用户信息   |
| train.hpp            | 车次信息   |
| railway_manager.hpp  | 主管理库   |
|                      |            |
|                      |            |
|                      |            |

## 对各文件的具体说明



## 代码规范

-   **命名规则**：类名、函数名、变量名取得有意义，尤其是类名及其接口等不要出现无意义的名字。具体规则

    -   所有`namespace`（除`sjtu`）、类名、类的`public`函数名、非类成员函数名全部使用Pascal命名法。

        如：`MyNamespace`, `MyClass`, `MyClass::MyPublicFunction()`

    -   所有非类`private`、`protected`变量使用驼峰命名法。

        如：`myVariable`

    -   **建议**所有类的`private`、`protected`成员（函数、变量）由单个下划线开头，后接驼峰命名法。由于`private`和`protected`的命名方式不统一一般不会造成太大影响，所以不做强制要求。

        如：`_myPrivateFunction()`, `_myPrivateVariable`

    -   全大写命名的常量用下划线分割。

        如：`MY_CONSTANT`

-   **代码风格**：操作符两侧是否有空格、大括号换行与否等不做要求，但请使代码可读性尽量高。

-   **注释**：由于有开发文档描述具体的接口，所以留一些方便自己维护和相互查错的注释就可以了。

-   **只允许在自己的函数中使用`using`及`using namespace`语句，禁止全局使用。**