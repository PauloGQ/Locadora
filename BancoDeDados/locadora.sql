-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 14-Nov-2019 às 22:54
-- Versão do servidor: 10.4.8-MariaDB
-- versão do PHP: 7.1.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `locadora`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `classificacao`
--

CREATE TABLE `classificacao` (
  `IdClassificacao` int(11) NOT NULL,
  `classificacao` varchar(55) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `classificacao`
--

INSERT INTO `classificacao` (`IdClassificacao`, `classificacao`) VALUES
(1, 'Livre'),
(2, '+10'),
(3, '+12'),
(4, '+14'),
(5, '+16'),
(6, '+18');

-- --------------------------------------------------------

--
-- Estrutura da tabela `cliente`
--

CREATE TABLE `cliente` (
  `IdCliente` int(11) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `DataNascimento` date NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Cpf` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `cliente`
--

INSERT INTO `cliente` (`IdCliente`, `Nome`, `DataNascimento`, `Email`, `Cpf`) VALUES
(24, 'Gabriel José Resende Cesarini', '1999-10-16', 'gabriel@gmail.com', '012012301232'),
(25, 'Paulo Vinícius Gomes de Queirós', '2000-05-16', 'paulo@gmail.com', '07450879140'),
(28, 'Giovanni de Lima', '2000-05-16', 'giovanni@gmail.com', '07451465'),
(29, 'Guilherme Lima', '1996-08-08', 'guilimag@gmail.com', '159654875');

-- --------------------------------------------------------

--
-- Estrutura da tabela `endereco`
--

CREATE TABLE `endereco` (
  `IdEndereco` int(11) NOT NULL,
  `Cep` varchar(10) NOT NULL,
  `Cidade` varchar(20) NOT NULL,
  `Estado` varchar(20) NOT NULL,
  `Bairro` varchar(40) NOT NULL,
  `Logradouro` varchar(50) NOT NULL,
  `Numero` varchar(10) NOT NULL,
  `Complemento` varchar(50) NOT NULL,
  `IdClienteFkEndereco` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `endereco`
--

INSERT INTO `endereco` (`IdEndereco`, `Cep`, `Cidade`, `Estado`, `Bairro`, `Logradouro`, `Numero`, `Complemento`, `IdClienteFkEndereco`) VALUES
(13, '72130123', 'Sobradinho', 'DF', 'Alagoinha', 'Qnq 45 casa 2', '104', 'Ao lado do shopping', 24),
(14, '72320-301', 'Brasília', 'DF', 'Samambaia Norte', 'qi 416 conj 1', '208', 'Residencial das Palmeiras ', 25),
(17, '72320-301', 'Brasília', 'DF', 'Vicente Pires', 'qi 416 conj 1', '156', 'Perto da Delegacia ', 28),
(18, '72320-301', 'Brasília', 'DF', 'Vicente Pires', 'qi 416 conj 1', '123', 'Perto da Delegacia ', 29);

-- --------------------------------------------------------

--
-- Estrutura da tabela `filme`
--

CREATE TABLE `filme` (
  `IdFilme` int(11) NOT NULL,
  `Nome` varchar(55) DEFAULT NULL,
  `Sinopse` varchar(500) NOT NULL,
  `TempoDuracao` varchar(55) NOT NULL,
  `Ano` varchar(4) NOT NULL,
  `IdClassificacao` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `filme`
--

INSERT INTO `filme` (`IdFilme`, `Nome`, `Sinopse`, `TempoDuracao`, `Ano`, `IdClassificacao`) VALUES
(1, 'Vingadores: Ultimato', 'Após Thanos eliminar metade das criaturas vivas, os Vingadores têm de lidar com a perda de amigos e entes queridos. Com Tony Stark vagando perdido no espaço sem água e comida, Steve Rogers e Natasha Romanov lideram a resistência contra o titã louco.', '3h 2m', '2019', 3),
(2, 'Coringa', 'O comediante falido Arthur Fleck encontra violentos bandidos pelas ruas de Gotham City. Desconsiderado pela sociedade, Fleck começa a ficar louco e se transforma no criminoso conhecido como Coringa.', '2h 2m', '2019', 5),
(3, 'Toy Story 4', 'Woody, Buzz Lightyear e o resto da turma embarcam em uma viagem com Bonnie e um novo brinquedo chamado Forky. A aventura logo se transforma em uma reunião inesperada quando o ligeiro desvio que Woody faz o leva ao seu amigo há muito perdido, Bo Peep.', '1h 40m', '2019', 1),
(4, 'O Rei Leão', 'Traído e exilado de seu reino, o leãozinho Simba precisa descobrir como crescer e retomar seu destino como herdeiro real nas planícies da savana africana.', '1h 58m', '2019', 1),
(5, 'Homem-Aranha: Longe de Casa', 'Peter Parker está em uma viagem de duas semanas pela Europa, ao lado de seus amigos de colégio, quando é surpreendido pela visita de Nick Fury. Convocado para mais uma missão heroica, ele precisa enfrentar vários vilões que surgem em cidades-símbolo do continente, como Londres, Paris e Veneza, e também a aparição do enigmático Mysterio.', '2h 9m', '2019', 3);

-- --------------------------------------------------------

--
-- Estrutura da tabela `funcionario`
--

CREATE TABLE `funcionario` (
  `IdFuncionarios` int(11) NOT NULL,
  `Nome` varchar(55) NOT NULL,
  `Email` varchar(55) NOT NULL,
  `Senha` varchar(55) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `funcionario`
--

INSERT INTO `funcionario` (`IdFuncionarios`, `Nome`, `Email`, `Senha`) VALUES
(1, 'Pedro Henrique', 'Pedrohgq@gmail.com', '160820'),
(2, 'Rafael Alencar', 'RafaAlencar@gmail.com', '553942');

-- --------------------------------------------------------

--
-- Estrutura da tabela `locacao`
--

CREATE TABLE `locacao` (
  `IdLocacao` int(11) NOT NULL,
  `IdCliente` int(11) DEFAULT NULL,
  `IdFilme` int(11) DEFAULT NULL,
  `IdFuncionario` int(11) DEFAULT NULL,
  `DataLocacao` date NOT NULL,
  `DataEntrega` date NOT NULL,
  `ValorLocacao` varchar(15) NOT NULL,
  `NumeroLocacao` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `telefone`
--

CREATE TABLE `telefone` (
  `IdTelefone` int(11) NOT NULL,
  `TipoTelefone` varchar(15) NOT NULL,
  `Ddd` varchar(4) NOT NULL,
  `NumeroTel` varchar(20) NOT NULL,
  `IdClienteFkTelefone` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `telefone`
--

INSERT INTO `telefone` (`IdTelefone`, `TipoTelefone`, `Ddd`, `NumeroTel`, `IdClienteFkTelefone`) VALUES
(14, 'telefone', '61', '33218181', 24),
(15, 'Celular', '61', '981679773', 25),
(18, 'Celular', '061', '123123123', 28),
(19, 'Fixo', '061', '985453948', 29);

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `classificacao`
--
ALTER TABLE `classificacao`
  ADD PRIMARY KEY (`IdClassificacao`);

--
-- Índices para tabela `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`IdCliente`);

--
-- Índices para tabela `endereco`
--
ALTER TABLE `endereco`
  ADD PRIMARY KEY (`IdEndereco`),
  ADD KEY `IdCliente` (`IdClienteFkEndereco`);

--
-- Índices para tabela `filme`
--
ALTER TABLE `filme`
  ADD PRIMARY KEY (`IdFilme`),
  ADD KEY `IdClassificacao` (`IdClassificacao`);

--
-- Índices para tabela `funcionario`
--
ALTER TABLE `funcionario`
  ADD PRIMARY KEY (`IdFuncionarios`);

--
-- Índices para tabela `locacao`
--
ALTER TABLE `locacao`
  ADD PRIMARY KEY (`IdLocacao`),
  ADD KEY `IdCliente` (`IdCliente`),
  ADD KEY `IdFilme` (`IdFilme`),
  ADD KEY `IdFuncionario` (`IdFuncionario`);

--
-- Índices para tabela `telefone`
--
ALTER TABLE `telefone`
  ADD PRIMARY KEY (`IdTelefone`),
  ADD KEY `IdCliente` (`IdClienteFkTelefone`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `classificacao`
--
ALTER TABLE `classificacao`
  MODIFY `IdClassificacao` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de tabela `cliente`
--
ALTER TABLE `cliente`
  MODIFY `IdCliente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- AUTO_INCREMENT de tabela `endereco`
--
ALTER TABLE `endereco`
  MODIFY `IdEndereco` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT de tabela `filme`
--
ALTER TABLE `filme`
  MODIFY `IdFilme` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de tabela `funcionario`
--
ALTER TABLE `funcionario`
  MODIFY `IdFuncionarios` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `locacao`
--
ALTER TABLE `locacao`
  MODIFY `IdLocacao` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `telefone`
--
ALTER TABLE `telefone`
  MODIFY `IdTelefone` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `endereco`
--
ALTER TABLE `endereco`
  ADD CONSTRAINT `endereco_ibfk_1` FOREIGN KEY (`IdClienteFkEndereco`) REFERENCES `cliente` (`IdCliente`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limitadores para a tabela `filme`
--
ALTER TABLE `filme`
  ADD CONSTRAINT `filme_ibfk_1` FOREIGN KEY (`IdClassificacao`) REFERENCES `classificacao` (`IdClassificacao`);

--
-- Limitadores para a tabela `locacao`
--
ALTER TABLE `locacao`
  ADD CONSTRAINT `locacao_ibfk_1` FOREIGN KEY (`IdCliente`) REFERENCES `cliente` (`IdCliente`),
  ADD CONSTRAINT `locacao_ibfk_2` FOREIGN KEY (`IdFilme`) REFERENCES `filme` (`IdFilme`),
  ADD CONSTRAINT `locacao_ibfk_3` FOREIGN KEY (`IdFuncionario`) REFERENCES `funcionario` (`idFuncionarios`);

--
-- Limitadores para a tabela `telefone`
--
ALTER TABLE `telefone`
  ADD CONSTRAINT `telefone_ibfk_1` FOREIGN KEY (`IdClienteFkTelefone`) REFERENCES `cliente` (`IdCliente`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
