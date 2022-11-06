# Back 

## ObjClass

包含所有基本类：Customer，Deliverer，Goods，Order，People，Store，My_image



Customer，Deliverer，Goods，Order，Store对应数据库里的表项，其中对Purchase的操作写在了Order里。

My_image是进行图片转换的类，里面有转换方法。

使用方法是XXX xxx=new XXX(参数);

修改属性有SetXXX()和GetXXX()方法

## SqlConn

接口fa：作为操作类的对外接口

### Op（操作类）

这里是实体类对应数据库的具体操作，分为三类Insert，update，delete。

其中对Purchase的操作写在了OrderSqlOp里

使用方法是：

XXXfa fa = new XXXSqlOp();

fa.XXX();

## 思路

每一个基本类是数据库中信息的暂时载体，存放到内存里。

用户对内存中的数据进行的操作是暂时的（掉电清空）

要想保存基本类的信息需要使用操作类的方法传入到数据库里。

当获取时需要从数据库里的表项需要创建相关基本类，然后将用接口传入基本类中

先将Customer接口添加上状态码返回功能，表明这个功能是否返回正确，若错误则可查阅微软官方状态码解释来处理https://learn.microsoft.com/zh-cn/sql/relational-databases/errors-events/database-engine-events-and-errors?view=sql-server-ver16

## 添加

1. 接口可以通过isHave()方法查询是否含有该项，这是通过sql里的存储过程和C#API接口实现的

2. 添加通过顾客号查找订单的功能

3. 添加图片加入数据库的功能

   [DataTableReader.GetBytes(Int32, Int64, Byte[\], Int32, Int32) 方法 (System.Data) | Microsoft Learn](https://learn.microsoft.com/zh-cn/dotnet/api/system.data.datatablereader.getbytes?view=net-6.0)
   
4. 实现了查询订单数量的函数GetOrderNum(),返回一个int数字（通过存储过程实现）