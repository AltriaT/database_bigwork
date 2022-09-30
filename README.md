 # 数据库大作业

## 系统设计与实现

### 一、摘要（概括性介绍应用系统的意义，体系结构，开发及运行所需的软件环境，用户类型及各类用户具备的主要功能模块）

这里将设计一个网上购物系统，类似于饿了么。本系统采用B/S结构，语言采用java制作后端，jsp和web作为前端，分为前端服务功能模块和后端管理功能模块。服务对象可以分为商户和顾客还有外卖员，商户可以开虚拟网络店铺，在店铺里可以放有关商品，顾客可以浏览店铺里的商品进行购买或者加入购物车，也可以和店家进行沟通，外卖员可以接订单，取消订单，完成订单。管理员可以控制和监管商家和用户的行为（创建、上架、购买、大数据分析等...）。

### 二、系统主要功能模块（用户类型及不同类型用户具备的主要功能模块）

![img](.\assets\wps1.jpg) 

### 三、E-R图（暂时不画，进一步分析、规划）

**说明：画出E-R****图。**

 

### 四、数据库设计

#### 1、数据库物理文件组织

![img](file:///C:\Users\11654\AppData\Local\Temp\ksohtml22656\wps2.jpg) 

**CREATE DATABASE TakeOut**

**ON PRIMARY**

**(NAME=TOFile1,**

**FILENAME='D:\TakeOut\TOFile1.mdf',**

**SIZE=7MB,**

**MAXSIZE=40MB,**

**FILEGROWTH=2MB),**

 

**FILEGROUP Group1**

**(NAME=TOGroup1File1,**

**FILENAME='D:\TakeOut\TOGroup1File1.mdf',**

**SIZE=4MB,**

**MAXSIZE=30MB,**

**FILEGROWTH=1MB),**

**(NAME=TOGroup1File2,**

**FILENAME='D:\TakeOut\TOGroup1File2.mdf',**

**SIZE=5MB,**

**MAXSIZE=20MB,**

**FILEGROWTH=2MB),**

 

**FILEGROUP GROUP2**

**(NAME=TOGroup2File1,**

**FILENAME='D:\TakeOut\TOGroup2File1.mdf',**

**SIZE=7MB,**

**MAXSIZE=20MB,**

**FILEGROWTH=3MB)**

 

**LOG ON**

**(NAME=TOLogFile1,**

**FILENAME='D:\TakeOut\TOLogFile1.ldf',**

**SIZE=6MB,**

**MAXSIZE=50MB,**

**FILEGROWTH=10%),**

 

**(NAME=TOLogFile2,**

**FILENAME='D:\TakeOut\TOLogFile2.ldf',**

**SIZE=3MB,**

**MAXSIZE=40MB,**

**FILEGROWTH=10%)**

 

**GO**

 

 

 

#### 2、数据库表结构设计

系统数据库各表的设计情况如下：

商店表（Store）：存储商店信息。

商店表（Store）

| 字段名称 | 字段类型    | 键码 | 其它完整性约束 | 属性含义   |
| -------- | ----------- | ---- | -------------- | ---------- |
| Sno      | varchar(20) | 主键 | Not null       | 商店号     |
| Spass    | varchar(20) |      | Not null       | 商店密码   |
| Sname    | varchar(50) |      | Not null       | 商店名称   |
| Saddr    | varchar(50) |      | Not null       | 商店地址   |
| Stel     | varchar(12) |      | Not null       | 商店电话   |
| Smoney   | int         |      | Not null       | 商店营业额 |
| Sstate   | varchar(20) |      | Not null       | 商店状态   |



商品表（Goods）：存储商品信息，如表所示。

商品表(Goods)

| 字段名称 | 字段类型                   | 键码 | 其它完整性约束 | 属性含义 |
| -------- | -------------------------- | ---- | -------------- | -------- |
| Gno      | varchar(20)                | 主键 | Not null       | 商品编号 |
| Sno      | varchar(20)                |      | Not null       | 商店编号 |
| Gname    | varchar(50)                |      | Not null       | 商品名称 |
| Gprice   | ***\**decimal(18,2)\**\*** |      | Not null       | 商品价格 |
| Gstock   | int                        |      | Not null       | 商品库存 |



顾客表（Customer）：存储顾客信息。

顾客表(Customer)

| 字段名称 | 字段类型    | 键码 | 其它完整性约束 | 属性含义 |
| -------- | ----------- | ---- | -------------- | -------- |
| Cno      | varchar(20) | 主键 |                | 顾客ID   |
| Cpass    | varchar(20) |      | Not null       | 登录密码 |
| Cname    | varchar(50) |      |                | 姓名     |
| Csex     | varchar(2)  |      |                | 性别     |
| Caddress | varchar(50) |      |                | 地址     |
| Ctel     | varchar(12) |      | Not null       | 电话     |

 

 

派送员表（Deliever）：存储派送员信息。

| 字段名称 | 字段类型    | 键码 | 其它完整性约束 | 属性含义 |
| -------- | ----------- | ---- | -------------- | -------- |
| Dno      | varchar(20) | 主键 |                | 派送员ID |
| Dpass    | varchar(20) |      | Not null       | 登录密码 |
| Dname    | varchar(50) |      |                | 姓名     |
| Dsex     | varchar(2)  |      |                | 性别     |
| Dstate   | varchar(20) |      |                | 状态     |
| Ctel     | varchar(12) |      | Not null       | 电话     |

 

订单表（Order）：存储订单信息。

| 字段名称 | 字段类型     | 键码 | 其它完整性约束 | 属性含义 |
| -------- | ------------ | ---- | -------------- | -------- |
| Ono      | varchar(20)  | 主键 |                | 订单号   |
| Dno      | varchar(20)  |      | Not null       | 骑手号   |
| Cno      | varchar(20)  |      |                | 顾客ID   |
| Sno      | varchar(20)  |      |                | 商店ID   |
| Ostate   | varchar(20)  |      | Not null       | 状态     |
| Otip     | varchar(100) |      |                | 备注     |
| ODelfee  | int          |      |                | 配送费   |
| Omoney   | int          |      |                | 金额     |
| Obtime   | datetime     |      |                | 发起时间 |

 

订单详情表（Purchase）：存储订单详情信息。

| 字段名称 | 字段类型    | 键码 | 其它完整性约束 | 属性含义 |
| -------- | ----------- | ---- | -------------- | -------- |
| Ono      | varchar(20) | 主键 |                | 订单号   |
| Gno      | varchar(20) |      | Not null       | 商品号   |
| Pamount  | int         |      |                | 数量     |

 

### 五、数据库关系图

**说明：SQL** **Server中****创建关系****图****，将图插入****此处。**

 

**其它****内容待续。。。。。。**
