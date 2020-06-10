drop database if exists SAMIbd;
create database SAMIbd;
use SAMIbd;

create table roles(
	IDRol int(10) primary key auto_increment,
    Rol varchar(45) NOT NULL
)engine = innoDB;

create table empleados(
	IDEmpleado int(10) primary key auto_increment,
    Nombres varchar(100) NOT NULL,
    Apellidos varchar(100) NOT NULL,
    Genero enum('MASCULINO','FEMENINO') NOT NULL
)engine = innoDB;

create table usuarios(
	IDUsuario int(10) primary key auto_increment,
    Usuario varchar(45) NOT NULL,
    Credencial varchar(200) NOT NULL,
    IDRol int(10) NOT NULL,
    IDEmpleado int(10) NOT NULL,
    foreign key (IDRol) references roles(IDRol),
    foreign key (IDEmpleado) references empleados(IDEmpleado)
)engine = innoDB;

create table Clasificaciones(
	IdClasificacion int(5) primary key auto_increment,
	Clasificacion varchar(100) NOT NULL
)engine = innoDB;

create table Proveedores(
	IDProveedor int(10) primary key auto_increment,
    NombreProveedor varchar(150) NOT NULL
)engine = innoDB;

create table Almacenamientos(
	IDAlmacenamiento int(10) primary key auto_increment,
    LugarAlmacenamiento varchar(150) NOT NULL
)engine = innoDB;

create table Productos(
	IDProducto int(10) primary key auto_increment,
	NombreProducto varchar(150) NOT NULL,
	Estado Enum('Nuevo','Usado') NOT NULL,
	IdClasificacion int(5) NOT NULL,
	Descripcion varchar(100),
	Cantidad int(10) NOT NULL,
	IDAlmacenamiento int(10) NOT NULL,
	Existencia Enum('En envio','Faltante','Existente') NOT NULL,
    Precio decimal(8,2) not null,
	foreign key (IdClasificacion) references Clasificaciones(IdClasificacion),
    foreign key (IDAlmacenamiento) references Almacenamientos(IDAlmacenamiento)
)engine = innoDB;

create table Pedidos(
	IdPedido int(10) primary key auto_increment,
	IDProveedor int(10) NOT NULL,
	Fecha_de_pedido date NOT NULL,
	TiempoPromedio int(10) NOT NULL,
    Costo decimal(8,2) not null,
    Estado Enum('Pedido','Recibido') NOT NULL,
	foreign key (IDProveedor) references Proveedores(IDProveedor)
)engine = innoDB;

create table Pedidos_Productos(
   IdPedido int(10) not null,
   IDProducto int(10) not null,
   Cantidad int(10) not null,
   foreign key(IdPedido) references Pedidos(IdPedido),
   foreign key(IDProducto) references Productos(IDProducto)
) engine = innoDB;

create table Registros(
	IdRegistro int(10) primary key auto_increment,
    IDUsuario int(10) NOT NULL,
    IDProducto int(10) NOT NULL,
    Accion enum('Retiro','Devolución','Inserción') NOT NULL,
    Cantidad int(10) NOT NULL,
    TiempoAccion datetime NOT NULL,
    foreign key (IDUsuario) references Usuarios(IDUsuario),
    foreign key (IDProducto) references Productos(IDProducto)
)engine = innoDB;

create table ClasificacionesSAMI(
	IDClasificacion int(10) primary key auto_increment,
    Clasificacion varchar(150) NOT NULL
)engine = innoDB;

create table Opciones(
	IDOpcion int(10) primary key auto_increment,
    Opcion varchar(150) NOT NULL,
    IDClasificacion int(10) NOT NULL,
    foreign key (IDClasificacion) references ClasificacionesSAMI(IDClasificacion)
)engine = innoDB;

create table Permisos(
	IDPermiso int(10) primary key auto_increment,
    IDOpcion int(10) NOT NULL,
    IDRol int(10) NOT NULL,
    foreign key (IDOpcion) references Opciones(IDOpcion),
    foreign key (IDRol) references roles(IDRol)
)engine = innoDB;


insert into roles values (1,'ADMINISTRADOR');
insert into roles values (2,'USUARIO');

insert into empleados values (1, 'Usuario','Administrador','MASCULINO');
insert into empleados values (2,'Kevin','Magaña','MASCULINO');
insert into empleados values (3,'Gerardo','Flores','MASCULINO');
insert into empleados values (4,'Oscar','Landaverde','MASCULINO');
insert into empleados values (5,'Usuario','user','MASCULINO');

insert into usuarios values (1,'admin',md5(sha1('12345')),1,1);
insert into usuarios values (2,'wolf',md5(SHA1('admin')),1,2);
insert into usuarios values (3,'oscar',md5(SHA1('admin')),1,3);
insert into usuarios values (4,'gerar',md5(SHA1('admin')),1,4);
insert into usuarios values (5,'user',md5(SHA1('user')),2,5);

Insert into Clasificaciones values (1,'Llantas');
Insert into Clasificaciones values (2,'Puertas');
Insert into Clasificaciones values (3,'Motores');
Insert into Clasificaciones values (4,'Ventanas');
Insert into Clasificaciones values (5,'Espejos');
Insert into Clasificaciones values (6,'Parte baja');

Insert into Almacenamientos values(1,'Zona 1');
Insert into Almacenamientos values(2,'Zona 2');
Insert into Almacenamientos values(3,'Zona 3');
Insert into Almacenamientos values(4,'Zona 4');
Insert into Almacenamientos values(5,'Zona 5');

Insert into Productos values (1,"Llanta N5",'Nuevo',1,'llanta te tipo n5',57,4,'Existente',2.50);
Insert into Productos values (2,"Llanta N2",'Nuevo',1,'llanta te tipo n2',2,4,'Existente',2.50);
Insert into Productos values (3,"Llanta N3",'Nuevo',1,'llanta te tipo n3',32,4,'Existente',2.50);
Insert into Productos values (4,"Llanta N1",'Nuevo',1,'llanta te tipo n1',0,4,'En envio',2.50);
Insert into Productos values (5,"Llanta N5",'Usado',1,'llanta te tipo n5',5,4,'existente',2.50);
Insert into Productos values (6,"Espejos laterales G2",'Nuevo',5,'Espejos laterales G2',17,2,'Existente',2.50);
Insert into Productos values (7,"Espejos laterales G1",'Nuevo',5,'Espejos laterales G1',24,2,'Existente',2.50);
Insert into Productos values (8,"Espejos laterales G2",'Usado',5,'Espejos laterales G2',0,2,'Faltante',2.50);
Insert into Productos values (9,"Motor v5",'Usado',3,'Motor de 8 cilindros',4,1,'Existente',2.50);
Insert into Productos values (10,"Motor v3",'Usado',3,'Motor de 8 cilindros',3,1,'Existente',2.50);
Insert into Productos values (11,"Motor v5",'Nuevo',3,'Motor de 8 cilindros',0,1,'Faltante',2.50);
Insert into Productos values (12,"Motor v4",'Usado',3,'Motor de 8 cilindros',0,1,'En envio',2.50);
Insert into Productos values (13,"Motor v8",'Usado',3,'Motor de 8 cilindros',2,1,'Existente',2.50);

Insert into Proveedores values(1,"Empresa A");
Insert into Proveedores values(2,"Empresa B");
Insert into Proveedores values(3,"Empresa C");
Insert into Proveedores values(4,"Empresa D");
Insert into Proveedores values(5,"Empresa E");
Insert into Proveedores values(6,"Empresa F");
Insert into Proveedores values(7,"Empresa G");

INSERT INTO Pedidos (IDProveedor, Fecha_de_pedido, TiempoPromedio, Costo, Estado) VALUES (7,'2019-04-26',15,15.89,'Pedido');
INSERT INTO Pedidos (IDProveedor, Fecha_de_pedido, TiempoPromedio, Costo, Estado) VALUES (2,'2019-04-26',78,15.89,'Pedido');
INSERT INTO Pedidos (IDProveedor, Fecha_de_pedido, TiempoPromedio, Costo, Estado) VALUES (4,'2019-04-26',24,15.89,'Pedido');
INSERT INTO Pedidos (IDProveedor, Fecha_de_pedido, TiempoPromedio, Costo, Estado) VALUES (1,'2019-04-26',32,15.89,'Pedido');
INSERT INTO Pedidos (IDProveedor, Fecha_de_pedido, TiempoPromedio, Costo, Estado) VALUES (5,'2019-04-26',56,15.89,'Pedido');
INSERT INTO Pedidos (IDProveedor, Fecha_de_pedido, TiempoPromedio, Costo, Estado) VALUES (3,'2019-04-26',89,15.89,'Pedido');
INSERT INTO Pedidos (IDProveedor, Fecha_de_pedido, TiempoPromedio, Costo, Estado) VALUES (1,'2019-04-26',1,15.89,'Pedido');
INSERT INTO Pedidos (IDProveedor, Fecha_de_pedido, TiempoPromedio, Costo, Estado) VALUES (1,'2019-04-26',9,15.89,'Pedido');

INSERT INTO Pedidos_Productos VALUES(1,1,8);
INSERT INTO Pedidos_Productos VALUES(1,2,12);
INSERT INTO Pedidos_Productos VALUES(1,1,3);
INSERT INTO Pedidos_Productos VALUES(1,1,6);
INSERT INTO Pedidos_Productos VALUES(1,1,7);
INSERT INTO Pedidos_Productos VALUES(1,1,23);
INSERT INTO Pedidos_Productos VALUES(4,1,45);
INSERT INTO Pedidos_Productos VALUES(4,1,8);
INSERT INTO Pedidos_Productos VALUES(4,2,12);
INSERT INTO Pedidos_Productos VALUES(6,1,3);
INSERT INTO Pedidos_Productos VALUES(3,1,6);


INSERT INTO ClasificacionesSAMI(Clasificacion) VALUES ('SISTEMA');
INSERT INTO ClasificacionesSAMI(Clasificacion) VALUES ('INVENTARIO');

INSERT INTO Opciones(Opcion, IDClasificacion) VALUES ('GESTION DE PRODUCTOS',1);
INSERT INTO Opciones(Opcion, IDClasificacion) VALUES ('MANEJO DE USUARIOS',1);
INSERT INTO Opciones(Opcion, IDClasificacion) VALUES ('ACCESO A BODEGA',1);
INSERT INTO Opciones(Opcion, IDClasificacion) VALUES ('ACCESO A HISTORIAL',2);
INSERT INTO Opciones(Opcion, IDClasificacion) VALUES ('MANEJO DE PEDIDOS',1);
INSERT INTO Opciones(Opcion, IDClasificacion) VALUES ('CONFIGURACION',1);
INSERT INTO Opciones(Opcion, IDClasificacion) VALUES ('REPORTES',2);

INSERT INTO Permisos(IDOpcion, IDRol) VALUES (1,1);
INSERT INTO Permisos(IDOpcion, IDRol) VALUES (2,1);
INSERT INTO Permisos(IDOpcion, IDRol) VALUES (3,1);
INSERT INTO Permisos(IDOpcion, IDRol) VALUES (4,1);
INSERT INTO Permisos(IDOpcion, IDRol) VALUES (5,1);
INSERT INTO Permisos(IDOpcion, IDRol) VALUES (6,1);
INSERT INTO Permisos(IDOpcion, IDRol) VALUES (7,1);
INSERT INTO Permisos(IDOpcion, IDRol) VALUES (3,2);

                
                
    
