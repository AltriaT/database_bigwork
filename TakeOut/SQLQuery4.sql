USE [TakeOut]
GO
/****** Object:  Trigger [dbo].[No_money]    Script Date: 2022/10/4 19:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--顾客余额小于当前订单的时候rollback订单
ALTER TRIGGER [dbo].[No_money]
ON [dbo].[orders]
AFTER INSERT,UPDATE
AS
BEGIN
	DECLARE @money_now int,@money_cust int,@num_cust varchar(20) 
	
	select @num_cust=Cno,@money_now=Omoney from inserted
	select @money_cust from Customer where Cno=@num_cust
	
	if(@money_cust<@money_now)
	BEGIN	
		print'余额不足，订单自动取消'		--实现功能时记得保存订单到临时表
		ROLLBACK TRANSACTION
	END
END
