-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 01, 2018 at 12:09 PM
-- Server version: 10.1.26-MariaDB
-- PHP Version: 7.1.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sistem_kos`
--

-- --------------------------------------------------------

--
-- Table structure for table `data_penghuni`
--

CREATE TABLE `data_penghuni` (
  `no_kamar` int(11) NOT NULL,
  `nama` varchar(50) NOT NULL,
  `no_dataDiri` varchar(50) NOT NULL,
  `alamat_asal` varchar(100) NOT NULL,
  `no_hp` varchar(20) NOT NULL,
  `pelunasan` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tabel_admin`
--

CREATE TABLE `tabel_admin` (
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `nama` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tabel_fasilitas`
--

CREATE TABLE `tabel_fasilitas` (
  `no_kamar` int(2) NOT NULL,
  `ukuran_kamar` varchar(50) NOT NULL,
  `tipe_kamar` varchar(50) NOT NULL,
  `kmLuar_dalam` varchar(50) NOT NULL,
  `meja` tinyint(1) NOT NULL,
  `kursi` tinyint(1) NOT NULL,
  `lemari` tinyint(1) NOT NULL,
  `televisi` tinyint(1) NOT NULL,
  `ac` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tabel_kamar`
--

CREATE TABLE `tabel_kamar` (
  `no_kamar` int(3) NOT NULL,
  `ketersediaan` tinyint(1) NOT NULL,
  `harga` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tabel_sewa`
--

CREATE TABLE `tabel_sewa` (
  `no_kamar` int(3) NOT NULL,
  `durasi` varchar(50) NOT NULL,
  `tanggal_masuk` date NOT NULL,
  `tanggal_keluar` date NOT NULL,
  `pelunasan` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tabel_kamar`
--
ALTER TABLE `tabel_kamar`
  ADD PRIMARY KEY (`no_kamar`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
