-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 13-Nov-2019 às 21:23
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
(1, 'Paulo Vinícius Gomes de Queirós', '0001-01-01', 'paulogq@gmail.com', '07450879140'),
(7, 'Larissa ', '1800-07-07', 'LariOtakaFedida@gmail.com', '696969696969'),
(8, 'Giovanni Lima', '1996-08-08', 'giovanni.limag@gmail.com', '707070707070');

-- --------------------------------------------------------

--
-- Estrutura da tabela `endereco`
--

CREATE TABLE `endereco` (
  `IdEndereco` int(11) NOT NULL,
  `Cep` varchar(10) NOT NULL,
  `Logradouro` varchar(50) NOT NULL,
  `Bairro` varchar(40) NOT NULL,
  `Cidade` varchar(20) NOT NULL,
  `Numero` varchar(10) NOT NULL,
  `Complemento` varchar(50) NOT NULL,
  `Estado` varchar(20) NOT NULL,
  `IdCliente` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `endereco`
--

INSERT INTO `endereco` (`IdEndereco`, `Cep`, `Logradouro`, `Bairro`, `Cidade`, `Numero`, `Complemento`, `Estado`, `IdCliente`) VALUES
(1, '72320301', 'Qi 416 conjunto 1', 'Samambaia', 'Brasilia', '208b', 'Residencal das Palmeiras', 'DF', 1);

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

--
-- Extraindo dados da tabela `locacao`
--

INSERT INTO `locacao` (`IdLocacao`, `IdCliente`, `IdFilme`, `IdFuncionario`, `DataLocacao`, `DataEntrega`, `ValorLocacao`, `NumeroLocacao`) VALUES
(1, 1, 2, 2, '2019-11-13', '2019-11-14', 'R$ 7,00', 1234);

-- --------------------------------------------------------

--
-- Estrutura da tabela `telefone`
--

CREATE TABLE `telefone` (
  `IdTelefone` int(11) NOT NULL,
  `TipoTelefone` varchar(15) NOT NULL,
  `Ddd` varchar(4) NOT NULL,
  `Numero` varchar(20) NOT NULL,
  `IdCliente` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `telefone`
--

INSERT INTO `telefone` (`IdTelefone`, `TipoTelefone`, `Ddd`, `Numero`, `IdCliente`) VALUES
(1, '55', '61', '981679773', 1);

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
  ADD KEY `IdCliente` (`IdCliente`);

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
  ADD KEY `IdCliente` (`IdCliente`);

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
  MODIFY `IdCliente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de tabela `endereco`
--
ALTER TABLE `endereco`
  MODIFY `IdEndereco` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

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
  MODIFY `IdTelefone` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `endereco`
--
ALTER TABLE `endereco`
  ADD CONSTRAINT `endereco_ibfk_1` FOREIGN KEY (`IdCliente`) REFERENCES `cliente` (`IdCliente`);

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
  ADD CONSTRAINT `telefone_ibfk_1` FOREIGN KEY (`IdCliente`) REFERENCES `cliente` (`IdCliente`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
