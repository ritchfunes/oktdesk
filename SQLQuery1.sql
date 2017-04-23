
select * from ticket
select * from aspnetusers 

select * from ticket where estado_ticket = 'asignar'
select * from ticket where estado_ticket = 'Asignado'
select * from ticket where estado_ticket = 'Reasignar'
select * from ticket where estado_ticket = 'Aceptar'
select * from ticket where estado_ticket = 'Verificar'
select * from ticket where estado_ticket = 'Calificar'

select * from ticket where estado_ticket = 'Calificado'

update ticket set estado_ticket = 'Verificar' where id_ticket = 19

select * from ticket where acti_encargado = 1 and aceptar = 0 

select * from aspnetusers where id_rol = 2 
select * from aspnetusers where id_rol = 3 

select * from aspnetusers where id_rol = 4 



update aspnetusers set  id_rol = 4 where Id = '1212'

delete from ticket where id_ticket = 11



alter procedure sp_upd_password
@email nvarchar(128),
@pasword nvarchar(128)
as
update AspNetUsers set PasswordHash = @pasword where  Email = @email 


exec sp_upd_password @email = 'ritchfunes@univision.com' , @pasword = 'Tempo+20'

select * from AspNetUsers
 