create table Held (
	held_id integer not null,
	held_name char(30) not null,
	held_eigenschaft char(30) not null,
	constraint pk_held primary key (held_id)
)

create table Agressor (
	agressor_id integer not null,
	agressor_name char(30) not null,
	agressor_eigenschaft char(30) not null,
	constraint pk_agressor primary key (agressor_id)
)

create table Bedrohung (
	bedrohung_id int not null,
	held_id int not null,
	agressor_id int not null,
	bedrohungsbezeichnung char(30) not null,
	constraint pk_bedrohung primary key (bedrohung_id),
	
	constraint fk_bedrohung_held foreign key (held_id)
	references held (held_id),
	
	constraint fk_bedrohung_agressor foreign key (agressor_id)
	references agressor (agressor_id)	
)
go

insert into held values (1, 'Tarzan', 'Recht schaffen')

insert into agressor values (1, 'Jane', 'streiten')

insert into bedrohung values (1, 1, 1, 'Urwaldreinigung')


