-- Criação das tabela secundárias

create table sexo (
    id_sex int primary key auto_increment,
    nome_sex varchar(20)
);

create table situacao (
    id_sit int primary key auto_increment,
    nome_sit varchar(20)
);

create table cargo (
    id_car int primary key auto_increment,
    nome_car varchar(50)
);

create table unidade_medida (
	id_uni int primary key auto_increment,
    nome_uni varchar(50)
);

-- Criação das tabelas principais 

create table funcionario (
    id_fun int primary key auto_increment,
    nome_fun varchar(100),
    data_nascimento_fun date,
    cpf_fun varchar(14),
    rg_fun varchar(15),
    telefone_fun varchar(15),
    endereco_fun varchar(150),
    bairro_fun varchar(60),
    cidade_fun varchar(60),
    estado_fun varchar(2),
    cep_fun varchar(9),
    email_fun varchar(100),
    salario_fun double,
    id_car_fk int,
    id_sit_fk INT,
    foreign key (id_car_fk) references cargo(id_car),
    foreign key (id_sit_fk) references situacao(id_sit)
);

create table cliente (
    id_cli int primary key auto_increment,
    nome_cli varchar(100) NOT NULL,
    cpf_cli varchar(14),
    telefone_cli varchar(15),
    endereco_cli varchar(150),
    bairro_cli varchar(60),
    cidade_cli varchar(60),
    estado_cli varchar(2),
    cep_cli varchar(9),
    complemento_cli varchar(100),
    email_cli varchar(100),
    observacoes_cli varchar(100),
    id_sex_fk int,
    id_sit_fk int,
    foreign key (id_sex_fk) references sexo(id_sex),
    foreign key (id_sit_fk) references situacao(id_sit)
);

create table fornecedor (
    id_for int primary key auto_increment,
    nome_fantasia_for varchar(100),
    razao_social_for varchar(100),
    proprietario_for varchar(100),
    cnpj_for varchar(18),
    inscricao_estadual_for varchar(20),
    telefone_for varchar(15),
    email_for varchar(100),
    endereco_for varchar(150),
    bairro_for varchar(60),
    cidade_for varchar(60),
    estado_for varchar(2),
    cep_for varchar(9),
    tributacao_for varchar(50),
    produtos_fornecidos_for varchar(1000),
    id_sit_fk int,
    foreign key (id_sit_fk) references situacao(id_sit)
);

create table categoria (
    id_cat int primary key auto_increment,
    nome_cat varchar(50),
    descricao_cat varchar(150),
    id_sit_fk int,
    foreign key (id_sit_fk) references situacao(id_sit)
);

create table produto (
    id_prod int primary key auto_increment,
    nome_prod varchar(100),
    preco_prod double,
    validade_prod date,
    marca_prod varchar(50),
    tipo_prod varchar(50),
    unidade_prod int, -- Obs: Essa unidade é a quantidade de produtos 
    estoque_minimo_prod int,
    estoque_maximo_prod int,
    id_for_fk int,
    id_cat_fk int,
    id_sit_fk int,
    foreign key (id_for_fk) references fornecedor (id_for),
    foreign key (id_cat_fk) references categoria (id_cat),
    foreign key (id_sit_fk) references situacao (id_sit)
);

create table servico (
    id_servico int primary key auto_increment,
    nome varchar(100),
    preco_ser double,
    duracao_ser int,
    id_sit_fk int,
    foreign key (id_sit_fk) references situacao(id_sit)
);

-- Inserimento de dados

insert into sexo values (null,'Masculino'), (null,'Feminino'), (null,'Outro');

insert into situacao values (null,'Ativo'), (null,'Inativo');

insert into cargo values (null,'Manicure'), (null,'Manicure e Pedicure'),(null,'Pedicure'), (null,'Nail Designer'), (null,'Atendente');

insert into unidade_medida values (null,'Unidade'), (null,'Litro'), (null,'Caixa'), (null,'Pacote');

insert into funcionario values
(null,'Brenda Izabeli', '2008-03-06', '123.456.789-00', 'RO-12.345.678', '(69) 9255-9545', 'Rua Bacuri, 61', 'Açaí', 'Ji-Paraná', 'RO', '30123-456', 'brenda@gmail.com', 2500.00, 1, 1),
(null,'Gabrielly da Silva', '2007-04-16', '059.877.242-10', 'RO-87.654.321', '(69)99327-5619', 'Rua Rio Branco,676', 'Jardim dos Migrantes', 'Ji-Paraná', 'RO', '30234-567', 'gabrielly@gmail.com', 3200.00, 2, 1),
(null,'Eduarda Oliveira', '2006-10-03', '111.222.333-44', 'RO-11.222.333', '(31)91234-8765', 'rua das orquídeas, 50', 'Nova Brasília', 'Ji-Paraná', 'RO', '30345-678', 'eduarda@email.com', 2800.00, 1, 1),
(null,'Maria Luiza', '2005-05-10', '555.666.777-88', 'RO-55.666.777', '(31)98765-4321', 'av. afonso pena, 300', 'centro', 'Ji-Paraná', 'RO', '30123-456', 'maria@gmail.com', 3000.00, 3, 1),
(null,'Sophie', '2008-03-08', '999.888.777-66', 'RO-99.888.777', '(31)97654-3210', 'rua são josé, 77', 'sagrada familia', 'Presidente Médice', 'RO', '30456-789', 'sophie@gmail.com', 3500.00, 2, 1);

-- tabela cliente
insert into cliente values
(null,'ana lima', '111.222.333-44', '(31)91234-1111', 'rua das orquídeas, 77', 'pampulha', 'belo horizonte', 'mg', '30345-678', 'apto 101', 'ana@email.com', 'cliente frequente', 2, 1),
(null,'carlos pereira', '555.666.777-88', '(31)91234-2222', 'av. afonso pena, 300', 'centro', 'belo horizonte', 'mg', '30123-456', 'sala 3', 'carlos@email.com', 'prefere pagamento no cartão', 1, 1),
(null,'juliana melo', '222.333.444-55', '(31)91234-3333', 'rua jacarandá, 12', 'sion', 'belo horizonte', 'mg', '30234-789', 'casa', 'juliana@email.com', 'primeira compra', 2, 1),
(null,'pedro alves', '333.444.555-66', '(31)91234-4444', 'av. américo vespúcio, 200', 'centro', 'belo horizonte', 'mg', '30123-890', 'apto 502', 'pedro@email.com', 'cliente antigo', 1, 1),
(null,'mariana costa', '444.555.666-77', '(31)91234-5555', 'rua das palmeiras, 10', 'pampulha', 'belo horizonte', 'mg', '30345-901', 'casa', 'mariana@email.com', 'solicita produtos veganos', 2, 1);

-- tabela fornecedor
insert into fornecedor values
(null,'beleza & cia', 'beleza e companhia ltda', 'marcos lima', '12.345.678/0001-99', '123456789', '(31)91234-3333', 'contato@beleza.com', 'rua das acácias, 50', 'sion', 'belo horizonte', 'mg', '30312-345', 'simples nacional', 'esmaltes, cremes, maquiagens', 1),
(null,'cosméticos brasil', 'cosmeticos brasil ltda', 'fernanda rodrigues', '98.765.432/0001-11', '987654321', '(31)91234-4444', 'vendas@cosmeticos.com', 'av. do contorno, 400', 'centro', 'belo horizonte', 'mg', '30123-678', 'lucro presumido', 'cremes, shampoos, esmaltes', 1),
(null,'arte cosméticos', 'arte cosmeticos ltda', 'paula melo', '11.222.333/0001-55', '112233445', '(31)91234-5555', 'contato@arte.com', 'rua alvorada, 22', 'sagrada familia', 'belo horizonte', 'mg', '30456-789', 'simples nacional', 'batons, sombras, pincéis', 1),
(null,'beleza total', 'beleza total ltda', 'ricardo santos', '22.333.444/0001-66', '223344556', '(31)91234-6666', 'vendas@total.com', 'av. américa, 100', 'centro', 'belo horizonte', 'mg', '30123-111', 'lucro presumido', 'esmaltes, perfumes, hidratantes', 1),
(null,'cosmetique', 'cosmetique ltda', 'aline costa', '33.444.555/0001-77', '334455667', '(31)91234-7777', 'contato@cosmetique.com', 'rua primavera, 45', 'pampulha', 'belo horizonte', 'mg', '30345-222', 'simples nacional', 'cremes, esmaltes, maquiagens', 1);

-- tabela categoria
insert into categoria values
(null,'esmaltes', 'esmaltes de diversas cores e marcas', 1),
(null,'maquiagem', 'produtos de maquiagem variados', 1),
(null,'cremes', 'cremes paramão e pés', 1),
(null,'acetona', 'solvente max', 1),
(null,'pincéis', 'pincéis para maquiagem', 1);

-- tabela produto
insert into produto values
(null,'esmalte vermelho', 5.50, '2026-12-31', 'colorfix', 'esmalte', 50, 10, 100, 1, 1, 1),
(null,'esmalte rosa', 12.00, '2027-06-30', 'impala', 'maquiagem', 30, 5, 50, 1, 1, 1),
(null,'creme hidratante', 25.00, '2026-05-20', 'pele macia', 'creme', 20, 5, 40, 2, 3, 1),
(null,'acetona', 7.50, '2027-12-31', 'solvente max', 'esmalte', 40, 5, 100, 1, 1, 1),
(null,'esfoliante', 15.00, '2026-07-30', 'oboticário', 'creme', 100, 10, 200, 2, 3, 1);

-- tabela servico
insert into servico values
(null,'manicure', 20.00, 60, 1),
(null,'pedicure', 25.00, 60, 1),
(null,'unha em gel', 50.00, 90, 1),
(null,'massagem relaxante', 80.00, 60, 1),
(null,'depilação', 40.00, 45, 1);