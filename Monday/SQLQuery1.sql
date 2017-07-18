create table Factura (
FacturaID int primary key identity(1,1),
ClientID int foreign key references Client(ClientID),
ComadaID int foreign key references Comanda(ComandaID)
)



create table LinieFactura (
LinieFacturaID int primary key identity(1,1),
FacturaID int foreign key references Factura(FacturaID),
LinieComandaID int foreign key references LinieComanda(LinieComandaID),
ProdusID int foreign key references Produs(ProdusID),
Pret decimal(8,2) not null,
Cantitate int
)

alter table Comanda
add Finalizata bit not null default(0)

--procedura care ...

alter procedure P_GenereazaFactura @ComandaId int
as
begin
	
	declare @ComandaFinalizata bit

	set @ComandaFinalizata = 
	(select Finalizata 
	from Comanda
	where ComandaID = @ComandaID)
	
	if @ComandaFinalizata<>0
	raiserror('Comanda a fost deja Finalizata',16,1)
	else
	begin
	update Comanda
	set Finalizata = 1
	where ComandaID = @ComandaID
	
	insert into Factura(ClientID, ComadaID)
	values ((
	select c.ClientID
	from Comanda as c
	
	where c.ComandaID = @ComandaId),
	@ComandaId
	)

	insert into LinieFactura (FacturaID,LinieComandaID,ProdusID,Pret,Cantitate)
	select Factura.FacturaID, LinieComanda.LinieComandaId,produs.ProdusID, produs.Pret, LinieComanda.Cantitate
	from Factura
	inner join LinieComanda on Factura.ComadaID = LinieComanda.ComandaID
	inner join produs on Produs.ProdusID = LinieComanda.ProdusID
	where Factura.ComadaID = @ComandaId
	end
end

P_GenereazaFactura  2

select * from factura
select * from LinieFactura

select * from produs
select * from LinieComanda
select * from Comanda

--Tranzactii

alter procedure P_GenereazaClientiTest @number int, @commit bit
as
begin

declare @contor int = 0
begin transaction 
	while(@contor < @number)
	begin
		insert into Client(Nume,Prenume,CNP)
		values (concat('Nume',cast(@contor as nvarchar(10))),concat('Prenume',cast(@contor as nvarchar(10))),replace('1234567891100',
																														substring('1234567891100',len('1234567891100')-len(@contor)+1,len(@contor)),
																														cast(@contor as nvarchar(100))))
		set @contor = @contor + 1
	end

	select * from Client

	if @commit <> 1
		begin 
		rollback tran
		end
	else
		begin 
		commit tran
		end
		
end

exec P_GenereazaClientiTest 100,0

select * from Client