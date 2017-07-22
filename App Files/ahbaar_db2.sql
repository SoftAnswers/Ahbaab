-- phpMyAdmin SQL Dump
-- version 4.4.15.8
-- https://www.phpmyadmin.net
--
-- Host: dedi802.your-server.de
-- Generation Time: Jul 22, 2017 at 10:28 AM
-- Server version: 5.5.55-0+deb8u1
-- PHP Version: 5.3.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ahbaar_db2`
--

-- --------------------------------------------------------

--
-- Table structure for table `about`
--

CREATE TABLE IF NOT EXISTS `about` (
  `about_desc_en` mediumtext CHARACTER SET utf8 NOT NULL,
  `about_desc_ar` mediumtext CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `about`
--

INSERT INTO `about` (`about_desc_en`, `about_desc_ar`) VALUES
('<p dir="ltr">\r\n	Under Copyright.</p>\r\n<p style="text-align: left;">\r\n	&nbsp;</p>\r\n<p style="text-align: left;">\r\n	&nbsp;</p>\r\n<p dir="ltr" style="">\r\n	&nbsp;</p>\r\n<p style="text-align: left;">\r\n	&nbsp;</p>\r\n', '<p align="right">\r\n	<span style="font-size:18px;"><strong>Ø´Ø±ÙˆØ· Ø§Ù„Ø¥Ø³ØªØ®Ø¯Ø§Ù…</strong></span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<strong><span dir="RTL">Ù…ÙˆÙ‚Ø¹ Ø§Ø­Ø¨Ø§Ø¨ Ù„Ù„ØªØ¹Ø§Ø±Ù ÙˆØ§Ù„Ø²ÙˆØ§Ø¬ ÙŠØ±ØºØ¨ Ø¨ÙƒÙ…</span></strong></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ø§Ù† Ø§Ø¯Ø§Ø±Ø© Ù…ÙˆÙ‚Øº Ø§Ø­Ø¨Ø§Ø¨ ÙŠØ±Ø­Ø¨ Ø¨ÙƒÙ… ÙˆÙŠØªÙ…Ù†Ù‰ Ù„ÙƒÙ… ÙƒÙ„ Ø§Ù„ØªÙˆÙÙŠÙ‚ ÙÙŠ Ø§Ù„Ù…ÙˆÙ‚Ø¹ ÙˆÙ„Ø°Ù„Ùƒ Ø§Ù„Ø±Ø¬Ø§Ø¡ Ù‚Ø±Ø§Ø¡Ø© Ø´Ø±ÙˆØ· Ø§Ù„Ø§Ø³ØªØ®Ø¯Ø§Ù… ÙˆØªØ­Ø°ÙŠØ±Ø§Øª Ø§Ù„Ø§Ù…Ø§Ù† Ù‚Ø¨Ù„ Ø§Ù„ØªØ³Ø¬ÙŠÙ„ ÙˆØ§Ù„Ø±Ø¬Ø§ Ø§Ù„Ø¹Ù…Ù„ Ø¨Ù‡Ø§ Ø¨ÙƒÙ„ Ø¯Ù‚Ø©</span></p>\r\n<p align="right">\r\n	<span dir="RTL">ÙŠØ¬Ø¨ Ø£Ù† Ù„Ø§ ÙŠÙƒÙˆÙ† Ø¹Ù…Ø± Ø§Ù„Ù…Ø´ØªØ±Ùƒ Ø£Ù‚Ù„ Ù…Ù† 18 Ø³Ù†Ø©</span>.</p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ù„Ù„Ø£Ø¹Ø¶Ø§Ø¡ Ø§Ù„Ø­Ù‚ ÙÙ‰ Ø§Ù†Ù‡Ø§Ø¡ Ø¹Ø¶ÙˆÙŠØªÙ‡Ù… ÙÙ‰ Ø§Ù‰ ÙˆÙ‚Øª ÙƒÙ…Ø§ ÙŠØ­Ù‚ Ù„Ù…ÙˆÙ‚Ø¹ <strong>Ø§Ø­Ø¨Ø§Ø¨ </strong>Ø£Ù† ØªÙ‚ÙˆÙ… Ø¨Ø§Ù„ØºØ§Ø¡ Ø¹Ø¶ÙˆÙŠØ© Ø£Ù‰ Ø¹Ø¶Ùˆ Ø¯ÙˆÙ† Ø§Ù„Ø±Ø¬ÙˆØ¹ Ø§Ù„ÙŠÙ‡,ÙƒÙ…Ø§ Ø£Ù†Ù‡ Ø§Ø°Ø§ Ø¨Ø¯Ø± Ù…Ù† Ø§Ù„Ø¹Ø¶Ùˆ Ø£Ù‰ Ù…Ø®Ø§Ù„ÙØ© Ù„Ø´Ø±ÙˆØ· Ø§Ù„Ø¹Ø¶ÙˆÙŠØ© ÙŠØªÙ… Ø§Ù†Ù‡Ø§Ø¡ Ø¹Ø¶ÙˆÙŠØªÙ‡</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">ÙŠØ­Ù‚ Ù„Ù…ÙˆÙ‚Ø¹ <strong>Ø§Ø­Ø¨Ø§Ø¨ </strong>Ø§ÙŠÙ‚Ø§Ù Ø§Ù‰ Ø¹Ø¶Ùˆ ÙŠØªØ¹Ø¯Ù‰ Ø¹Ù„Ù‰ Ø§Ù„Ù…ÙˆÙ‚Ø¹ Ø¨Ø§Ù‰ Ø´ÙƒÙ„ Ù…Ù† Ø§Ù„Ø§Ø´ÙƒØ§Ù„ Ø³ÙˆØ§Ø¡ ÙƒØªØ§Ø¨ÙŠØ§ Ø§Ùˆ Ù„ÙØ¸ÙŠØ§</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">ÙŠØ­Ù‚ Ù„Ù…ÙˆÙ‚Ø¹&nbsp;<strong>Ø§Ø­Ø¨Ø§Ø¨ </strong>Ø§ÙŠÙ‚Ø§Ù Ø§Ù‰ Ø¹Ø¶Ùˆ ÙŠØªØ¹Ø¯Ù‰ Ø¹Ù„Ù‰ Ø§Ù‰ Ù…Ø´ØªØ±Ùƒ Ø¯Ø§Ø®Ù„ Ù…ÙˆÙ‚Ø¹ <strong>Ø§Ø­Ø¨Ø§Ø¨ </strong>Ø¨Ø§Ù„ÙØ§Ø¸ Ø®Ø§Ø±Ø¬Ù‡ Ø¹Ù† Ø§Ù„Ø¹Ø±Ù</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ø§Ø¯Ø§Ø±Ø© Ø§Ù„Ù…ÙˆÙ‚Ø¹ Ù„Ø§ ØªÙ‚ÙˆÙ… Ø¨Ø§Ø¹Ø·Ø§Ø¡ Ø§ÙŠØ© Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø¹Ù† Ø§ÙŠ Ù…Ø´ØªØ±Ùƒ Ù„Ø§ÙŠ Ø´Ø®Øµ ÙƒØ§Ù† Ø§Ùˆ Ù„Ø§ÙŠ Ø¬Ù‡Ø© ÙƒØ§Ù†Øª Ù…Ù‡Ù…Ø§ ÙƒØ§Ù†Øª Ø§Ù„Ø§Ø³Ø¨Ø§Ø¨ ÙˆØ§Ù„Ø¸Ø±ÙˆÙ</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ø§Ù„Ù…ÙˆÙ‚Ø¹ Ù„Ø§ ÙŠÙ‚ÙˆÙ… Ø¨Ø§Ù„ØªØ§ÙƒØ¯ Ù…Ù† Ø§Ù„Ù…Ø´Ø§Ø±ÙƒÙŠÙ† Ø§Ùˆ Ø§Ù„Ù…Ø´Ø§Ø±ÙƒØ§Øª ÙÙŠ Ø§Ù„Ù…ÙˆÙ‚Ø¹ ÙˆÙ„Ø§ Ù…Ù† Ø¹Ù†ÙˆØ§ÙŠÙ†Ù‡Ù… ÙˆÙ„Ø§ Ø§Ø±Ù‚Ø§Ù…Ù‡Ù… Ù„Ø°Ù„Ùƒ Ù†Ù†ØµØ­ÙƒÙ… Ø¨Ø§Ù„ØªØ§ÙƒØ¯ Ù…Ø¹ Ø§Ù„Ø´Ø®Øµ Ø§Ù„Ù„Ø°ÙŠ ØªØªØ­Ø¯Ø«ÙˆÙ† Ù…Ø¹Ù‡ Ø¨Ø§Ù†ÙØ³ÙƒÙ…</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ø§Ø¯Ø§Ø±Ø© Ø§Ù„Ù…ÙˆÙ‚Ø¹ Ù„Ø§ ØªÙ‚ÙˆÙ… Ø§Ø·Ù„Ø§Ù‚Ø§ Ø¨Ù…Ø±Ø§Ù‚Ø¨Ø© Ø§Ù„Ø±Ø³Ø§Ø¦Ù„ Ø§Ù„Ù…ØªØ¨Ø§Ø¯Ù„Ù‡ Ø¨ÙŠÙ† Ø§Ù„Ù…Ø´Ø§Ø±ÙƒÙŠÙ† Ù„Ø§Ù†Ù†Ø§ Ù†Ø¹ØªØ¨Ø± Ø§Ù†Ù‡Ø§ Ø§Ù…ÙˆØ± Ø®Ø§ØµØ© Ù„Ø§ Ù†Ø³Ù…Ø­ Ù„Ø§ÙŠ Ù…Ù† Ù…Ø´Ø±ÙÙŠÙ†Ø§ Ø§Ùˆ Ù…ÙˆØ¸ÙÙŠÙ†Ø§ Ø¨Ø§Ù„Ø§Ø·Ù„Ø§Ø¹ Ø¹Ù„ÙŠÙ‡Ø§ ÙˆÙ„ÙƒÙ† ÙÙ‚Ø· ÙÙŠ Ø­Ø§Ù„ ÙˆØ¬ÙˆØ¯ Ø§ÙŠ Ø´ÙƒÙˆÙ‰ Ù…Ù† Ø§Ù„Ø±Ø³Ø§ÙŠÙ„ Ø¨Ø§Ù†Ù‡Ø§ ØªØ®Ø§Ù„Ù Ø´Ø±ÙˆØ· Ø§Ù„Ù…ÙˆÙ‚Ø¹ ÙŠÙ‚ÙˆÙ… ÙØ±ÙŠÙ‚ Ø§Ù„Ù…ÙˆÙ‚Ø¹ Ø¨Ø§Ù„Ø¯Ø®ÙˆÙ„ Ø§Ù„Ù‰ Ø§Ù„Ø±Ø³Ø§Ø¦Ù„ ÙˆÙ…Ø±Ø§Ù‚Ø¨ØªÙ‡Ø§</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ø§Ù„Ù…ÙˆÙ‚Ø¹ Ù„Ù„Ø§Ø³ØªØ®Ø¯Ø§Ù… Ø§Ù„Ø´Ø®ØµÙ‰ ÙÙ‚Ø· ÙˆØºÙŠØ± Ù…Ø³Ù…ÙˆØ­ Ø¨Ø§Ø³ØªØ®Ø¯Ø§Ù… Ø§Ù„Ù…ÙˆÙ‚Ø¹ ØªØ¬Ø§Ø±ÙŠØ§Ù‹ Ù…Ù† Ù‚Ø¨Ù„ Ø§Ù„Ø£Ø¹Ø¶Ø§Ø¡ Ø¨Ø£Ù‰ ØµÙˆØ±Ø© ÙƒØ§Ù†Øª ÙˆÙ…Ù† ÙŠÙØ¹Ù„ Ø°Ù„Ùƒ ÙŠØ¹Ø±Ø¶ Ù†ÙØ³Ù‡ Ù„Ù„Ù…Ø³Ø§Ø¡Ù„Ø© Ø§Ù„Ù‚Ø§Ù†ÙˆÙ†ÙŠØ© Ù…Ø¹ Ø§Ù†Ù‡Ø§Ø¡ Ø¹Ø¶ÙˆÙŠØªÙ‡</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ù„Ù„Ù…ÙˆÙ‚Ø¹ Ø§Ù„Ø­Ù‚ ÙÙ‰ ØªØ¹Ø¯ÙŠÙ„ Ø£Ùˆ Ø§Ù„ØºØ§Ø¡ Ø§Ù‰ Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ù…ÙˆØ¬ÙˆØ¯Ø© ÙÙ‰ Ø§Ù„Ù…ÙˆÙ‚Ø¹ Ø¨Ù…Ø§ ÙÙ‰ Ø°Ù„Ùƒ Ø§Ù„Ø¨ÙŠØ§Ù†Ø§Øª Ø§Ù„ØªÙ‰ ÙŠÙ‚ÙˆÙ… Ø§Ù„Ø§Ø¹Ø¶Ø§Ø¡ Ø¨Ø§Ø¯Ø®Ø§Ù„Ù‡Ø§ ÙˆØ§Ù„ØªÙ‰ Ù‚Ø¯ Ù„Ø§ØªØªÙ†Ø§Ø³Ø¨ Ù…Ø¹ Ù„ÙˆØ§Ø¦Ø­ Ø§Ù„Ø¹Ù…Ù„ ÙÙ‰ Ø§Ù„Ù…ÙˆÙ‚Ø¹ Ø§Ùˆ ØºÙŠØ± Ù…ØªÙÙ‚Ø© Ù…Ø¹ Ø§Ù„Ù‚ÙŠÙ… ÙˆØ§Ù„ØªÙ‚Ø§Ù„ÙŠØ¯ Ø£Ùˆ ØªØ¯Ø¹ÙˆØ§ Ø§Ù„Ù‰ Ø§Ù„ÙƒØ±Ø§Ù‡ÙŠØ© Ø£Ùˆ Ø§ØªØ¬Ø§Ù‡Ø§Øª ÙÙƒØ±ÙŠØ© Ø£Ùˆ Ø³ÙŠØ§Ø³ÙŠØ© Ø£Ùˆ ØªØ­ØªÙˆÙ‰ Ø¹Ù„Ù‰ Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø¯Ø¹Ø§Ø¦ÙŠØ© Ø£Ùˆ ØªØ¬Ø§Ø±ÙŠØ© Ø§Ùˆ Ø¹Ù†Ø§ÙˆÙŠÙ† Ù…ÙˆØ§Ù‚Ø¹ Ø§Ùˆ Ø¨Ø±ÙŠØ¯ Ø§Ù„ÙŠÙƒØªØ±ÙˆÙ†Ù‰</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ù„Ù† ØªØªÙ… Ø§Ù„Ù…ÙˆØ§ÙÙ‚Ø© Ø¹Ù„Ù‰ Ø§Ù‰ Ø·Ù„Ø¨ Ù„Ù„ØªÙˆØ§ØµÙ„ ÙÙ‰ Ø­Ø§Ù„Ø© Ø§Ù† Ù…Ù„Ù Ø§Ù„Ø¨ÙŠØ§Ù†Ø§Øª Ù„Ù„Ø¹Ø¶Ùˆ ØºÙŠØ± Ù…ÙƒØªÙ…Ù„</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ø¹Ø¯Ù… Ø§Ø±Ø³Ø§Ù„ Ø§ÙŠ Ù…Ø¨Ù„Øº Ù…Ø§Ø¯ÙŠ Ø§Ù„Ù‰ Ø§ÙŠ Ù…Ø´Ø§Ø±Ùƒ Ù…Ù‡Ù…Ø§ ÙƒØ§Ù†Øª Ø§Ù„Ø§Ø³Ø¨Ø§Ø¨ ÙˆØ§Ù„Ø¸Ø±ÙˆÙ</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ø¹Ø¯Ù… Ø§Ø¹Ø·Ø§Ø¡ Ø§ÙŠ Ù…Ø´Ø§Ø±Ùƒ Ø§Ø®Ø± Ø¹Ù†ÙˆØ§Ù† Ø³ÙƒÙ†ÙƒÙ… Ø§Ù„Ø§ØµÙ„ÙŠ ÙˆØ°Ù„Ùƒ Ù‚Ø¨Ù„ Ø§Ù„ØªØ§ÙƒØ¯ Ù…Ù† Ø§Ù„Ø´Ø®Øµ Ø§Ù„Ù…Ù‚Ø§Ø¨Ù„ Ù‚Ø¨Ù„ Ø§Ù„ØªØ§ÙƒØ¯ Ù…Ù† Ù†ÙˆØ§ÙŠØ§Ù‡ ÙˆÙ‡Ø¯ÙÙ‡</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ø¹Ø¯Ù… Ø§Ø¹Ø·Ø§Ø¡ Ø§ÙŠÙ‡ ØªÙØ§ØµÙŠÙ„ Ø¹Ù† Ø­Ø³Ø§Ø¨Ø§ØªÙƒÙ… Ø§Ù„Ù…ØµØ±ÙÙŠØ© Ù…Ù† Ø­Ø³Ø§Ø¨Ø§Øª Ø¹Ø§Ø¯ÙŠØ© Ø§Ùˆ Ø¨Ø·Ø§Ù‚Ø§Øª Ø§Ø¦ØªÙ…Ø§Ù†ÙŠØ© ÙˆØ¹Ø¯Ù… Ø§Ø¹Ø·Ø§Ø¡ Ø§ÙŠÙ‡ Ø§Ø±Ù‚Ø§Ù… Ø³Ø±ÙŠØ© Ø§Ùˆ Ø§Ø±Ù‚Ø§Ù… Ø¯Ø®ÙˆÙ„ Ø§Ù„Ù‰ Ø§ÙŠ Ø§Ø­Ø¯ ÙÙŠ Ø§Ù„Ù…ÙˆÙ‚Ø¹</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">ÙŠÙ…Ù†Ø¹ ØªÙ…Ø§Ù…Ø§ </span>&nbsp;<span dir="RTL">Ø±ÙØ¹ Ø§Ù‰ ØµÙˆØ±Ù‡ ØºÙŠØ± Ø§Ù„ØµÙˆØ± Ø§Ù„Ø´Ø®ØµÙŠØ© Ù„Ù„Ø§Ø¹Ø¶Ø§Ø¡ Ø§Ù„Ø°ÙƒÙˆØ± ÙƒÙ…Ø§ ÙŠÙ…Ù†Ø¹ Ø±ÙØ¹ ØµÙˆØ± Ø§Ù„Ù…Ø´Ø§Ù‡ÙŠØ±</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">ÙŠÙ…Ù†Ø¹ Ø§Ø³ØªØ®Ø¯Ø§Ù… Ø§Ù„Ø§Ø³Ù…Ø§Ø¡ ÙˆØ§Ù„Ø¹Ø¨Ø§Ø±Ø§Øª Ø§Ù„Ù…Ø®Ù„Ø© Ø¨Ø§Ù„Ø§Ø¯Ø§Ø¨ . Ù…Ø«Ù„ ( Ù…Ø«ÙŠØ± - Ø­Ø§Ø± Ø¬Ø¯Ø§ - Ø§Ø¹Ø´Ù‚ Ø§Ù„Ù†Ø³Ø§Ø¡</span> )</p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">ÙŠÙ…Ù†Ø¹ Ø±ÙØ¹ Ø§Ù„ØµÙˆØ±Ù‡ Ø§Ù„ÙØ§Ø¶Ø­Ù‡ØŒ Ø³ÙˆØ§Ø¡ ØµÙˆØ± Ø´Ø®ØµÙŠØ© Ø§Ùˆ ØµÙˆØ± Ù…Ù† Ø§Ù„Ø§Ù†ØªØ±Ù†Øª . Ø§Ù„ØµÙˆØ± ÙÙ‚Ø· Ø¹Ø¨Ø§Ø±Ù‡ Ø¹Ù† ØµÙˆØ± Ø¹Ø§Ø¯ÙŠØ© Ù…ØªØ­Ø´Ù…Ø©</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ø§Ù„Ù…ÙˆÙ‚Ø¹ ØºÙŠØ± Ù…Ø³Ø¤ÙˆÙ„ Ø¹Ù† Ø£ÙŠ Ù†ØªØ§Ø¦Ø¬ Ø³Ù„Ø¨ÙŠÙ‡ Ù„Ø§Ù‰ ØªØ¹Ø§Ø±Ù Ø®Ø§Ø±Ø¬ Ø§Ù„Ù…ÙˆÙ‚Ø¹ Ù…Ù† Ø®Ù„Ø§Ù„ Ø§Ù„Ø¨Ø±ÙŠØ¯ Ø§Ùˆ Ø§Ù„ØªÙ„ÙŠÙÙˆÙ†</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ø§Ù„Ù…ÙˆÙ‚Ø¹ ØºÙŠØ± Ù…Ø³Ø¤Ù„ Ø¹Ù† Ø§Ù‰ Ù†ØªØ§Ø¦Ø¬ ØªØªØ±Ø¨ Ø¹Ù„Ù‰ Ø§ÙØµØ§Ø­Ùƒ Ø¹Ù† Ø¨ÙŠØ§Ù†Ø§ØªÙƒ Ø§Ù„Ø®Ø§ØµÙ‡ Ù„Ø§Ù‰ Ù…Ø´ØªØ±Ùƒ ÙÙ‰ Ø§Ù„Ù…ÙˆÙ‚Ø¹</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ø§Ù„Ù…ÙˆÙ‚Ø¹ ØºÙŠØ± Ù…Ø³Ø¤Ù„ Ø¹Ù† Ø§Ù‰ Ù†ØªØ§Ø¦Ø¬ Ø³Ù„Ø¨ÙŠÙ‡ Ù„ÙˆØ¶Ø¹ ØµÙˆØ± Ø§Ù„Ø¨Ù†Ø§Øª Ø§Ù„Ø±Ø§ØºØ¨Ø§Øª ÙÙ‰ Ø§Ù„Ø²ÙˆØ§Ø¬ Ù…Ù† Ø®Ù„Ø§Ù„ Ø§Ù„Ù…ÙˆÙ‚Ø¹</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">ÙŠÙ…ÙƒÙ† Ù„Ø§Ù‰ Ù…Ø´ØªØ±Ùƒ Ø§Ù„ØªÙ‚Ø¯Ù… Ø¨Ø¨Ù„Ø§Øº Ø¹Ù† Ø§Ù‰ Ø´Ø®Øµ Ù…Ø®Ø§Ù„Ù Ø¯Ø§Ø®Ù„ Ø§Ù„Ù…ÙˆÙ‚Ø¹ Ø§Ùˆ Ø´Ø®Øµ Ù‡Ø¯ÙÙ‡ Ø§Ù„ØªØ³Ù„ÙŠØ©</span></p>\r\n<p align="right">\r\n	&nbsp;&nbsp;</p>\r\n');

-- --------------------------------------------------------

--
-- Table structure for table `accounts`
--

CREATE TABLE IF NOT EXISTS `accounts` (
  `account_id` int(10) NOT NULL,
  `username` varchar(200) CHARACTER SET utf8 NOT NULL,
  `password` varchar(200) CHARACTER SET utf8 NOT NULL,
  `email` varchar(300) CHARACTER SET utf8 NOT NULL,
  `name` varchar(400) CHARACTER SET utf8 NOT NULL,
  `gender` varchar(1) CHARACTER SET utf8 NOT NULL,
  `status_id` int(3) NOT NULL,
  `IP` varchar(20) CHARACTER SET utf8 NOT NULL,
  `last_active_date` date NOT NULL,
  `created_on` date NOT NULL,
  `eye_color_id` int(3) NOT NULL,
  `hair_color_id` int(3) NOT NULL,
  `height_id` int(3) NOT NULL,
  `weight_id` int(3) NOT NULL,
  `usage_purpose_id` int(3) NOT NULL,
  `age_id` int(3) NOT NULL,
  `educ_level_id` int(3) NOT NULL,
  `origin_ctry_id` int(6) NOT NULL,
  `current_ctry_id` int(6) NOT NULL,
  `job_id` int(6) NOT NULL,
  `describe_you` varchar(10000) CHARACTER SET utf8 NOT NULL,
  `describe_others` varchar(10000) CHARACTER SET utf8 NOT NULL,
  `phone_number` varchar(15) CHARACTER SET utf8 NOT NULL,
  `paid` varchar(1) CHARACTER SET utf8 NOT NULL,
  `visit_count_to` int(10) NOT NULL,
  `visit_count_from` int(10) NOT NULL,
  `interests_to` int(10) NOT NULL,
  `interests_from` int(10) NOT NULL,
  `blocks_to` int(10) NOT NULL,
  `blocks_from` int(10) NOT NULL,
  `logins` int(10) NOT NULL,
  `active` int(1) NOT NULL,
  `time_frame_id` int(3) NOT NULL,
  `paid_begin` date NOT NULL,
  `paid_end` date NOT NULL,
  `account_status` varchar(1) CHARACTER SET utf8 NOT NULL,
  `timezone_id` int(3) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=52 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `accounts`
--

INSERT INTO `accounts` (`account_id`, `username`, `password`, `email`, `name`, `gender`, `status_id`, `IP`, `last_active_date`, `created_on`, `eye_color_id`, `hair_color_id`, `height_id`, `weight_id`, `usage_purpose_id`, `age_id`, `educ_level_id`, `origin_ctry_id`, `current_ctry_id`, `job_id`, `describe_you`, `describe_others`, `phone_number`, `paid`, `visit_count_to`, `visit_count_from`, `interests_to`, `interests_from`, `blocks_to`, `blocks_from`, `logins`, `active`, `time_frame_id`, `paid_begin`, `paid_end`, `account_status`, `timezone_id`) VALUES
(30, 'test123', 'test123', 'nasrnassar14@gmail.com', 'Nasr Nassar', 'M', 4, '94.207.132.173', '2016-12-03', '2016-12-03', 1, 3, 1, 4, 4, 5, 1, 1, 1, 6, 'test description ', 'test partner description ', '', 'N', 0, 0, 0, 0, 0, 0, 1, 1, 5, '1988-01-01', '1988-01-01', 'P', 2),
(31, 'nen001', 'test1234', 'nasr.nassar@live.com', 'nasr nassar', 'M', 1, '91.73.107.48', '2016-12-17', '2016-12-17', 1, 3, 1, 1, 1, 7, 6, 6, 7, 9, 'test description \n', 'test description', '', 'N', 0, 0, 0, 0, 0, 0, 1, 1, 4, '1988-01-01', '1988-01-01', 'A', 2),
(32, 'nen101', 'nen102345', 'nasrnassar14@gmail.com', 'Nasr Nassar', 'M', 1, '5.31.183.219', '2017-02-03', '2017-02-03', 5, 7, 1, 3, 7, 8, 1, 4, 5, 8, 'test self description app', 'test partner description app', '', 'N', 0, 0, 0, 0, 0, 0, 1, 1, 5, '1988-01-01', '1988-01-01', 'A', 2),
(33, 'nasr.nassar', 'password123456', 'nasrnassar14@gmail.com', 'Nasr Nassar', 'M', 1, '5.31.183.219', '2017-02-03', '2017-02-03', 1, 3, 1, 3, 6, 7, 3, 6, 5, 8, 'test self description app ', 'test partner description app ', '', 'N', 0, 0, 0, 0, 0, 0, 1, 1, 4, '1988-01-01', '1988-01-01', 'A', 2),
(34, 'joejoe', 'test123', 'test@test.com', 'Joe joe', 'M', 1, '91.232.101.29', '2017-02-06', '2017-02-06', 2, 5, 1, 4, 1, 5, 3, 3, 3, 5, 'test', 'test', '', 'N', 0, 0, 0, 0, 0, 0, 1, 1, 3, '1988-01-01', '1988-01-01', 'A', 2),
(35, 'kiko', 'kiko123', 'test@hotmail.com', 'kilo kiko', 'M', 3, '178.135.155.195', '2017-02-08', '2017-02-08', 3, 5, 1, 3, 3, 4, 3, 3, 3, 0, '', '', '', 'N', 0, 0, 0, 0, 0, 0, 1, 1, 4, '1988-01-01', '1988-01-01', 'P', 2),
(36, 'kiko', 'kiko123', 'test@hotmail.com', 'kilo kiko', 'M', 3, '178.135.155.195', '2017-02-08', '2017-02-08', 3, 5, 1, 3, 3, 4, 3, 3, 3, 0, '', '', '', 'N', 0, 0, 0, 0, 0, 0, 1, 1, 4, '1988-01-01', '1988-01-01', 'P', 2),
(37, 'kiko', 'kiko123', 'test@hotmail.com', 'kilo kiko', 'M', 3, '178.135.155.195', '2017-02-08', '2017-02-08', 3, 5, 1, 3, 3, 4, 3, 3, 3, 0, '', '', '', 'N', 0, 0, 0, 0, 0, 0, 1, 1, 4, '1988-01-01', '1988-01-01', 'P', 2),
(38, 'kika', 'kika123', 'test@hotmail.com', 'kikakika', 'F', 3, '178.135.155.195', '2017-02-08', '2017-02-08', 1, 5, 3, 5, 3, 0, 3, 3, 3, 5, 'uuu', 'jjj', '', 'Y', 0, 0, 0, 0, 0, 0, 1, 1, 4, '1988-01-01', '1988-01-01', 'P', 2),
(39, 'kika', 'kika123', 'test@hotmail.com', 'kikakika', 'F', 3, '178.135.155.195', '2017-02-08', '2017-02-08', 1, 5, 3, 5, 3, 0, 3, 3, 3, 5, 'uuu', 'jjj', '', 'Y', 0, 0, 0, 0, 0, 0, 1, 1, 4, '1988-01-01', '1988-01-01', 'P', 2),
(40, 'biss', 'biss123', 'bassel.abouabdo@hotmail.com', 'biss', 'M', 1, '91.232.101.48', '2017-02-24', '2017-02-24', 1, 6, 3, 3, 3, 1, 3, 1, 3, 4, 'test', 'test', '', 'N', 0, 0, 0, 0, 0, 0, 1, 1, 3, '1988-01-01', '1988-01-01', 'P', 2),
(41, 'biss', 'biss123', 'bassel.abouabdo@hotmail.com', 'biss', 'M', 1, '91.232.101.48', '2017-02-24', '2017-02-24', 1, 6, 3, 3, 3, 1, 3, 1, 3, 4, 'test', 'test', '', 'N', 0, 0, 0, 0, 0, 0, 1, 1, 3, '1988-01-01', '1988-01-01', 'P', 2),
(42, 'biss', 'biss123', 'bassel.abouabdo@hotmail.com', 'biss', 'M', 1, '91.232.101.48', '2017-02-24', '2017-02-24', 1, 6, 3, 3, 3, 1, 3, 1, 3, 4, 'test', 'test', '', 'N', 0, 0, 0, 0, 0, 0, 1, 1, 3, '1988-01-01', '1988-01-01', 'P', 2),
(43, 'biss', 'biss123', 'bassel.abouabdo@hotmail.com', 'biss', 'M', 1, '91.232.101.48', '2017-02-24', '2017-02-24', 1, 6, 3, 3, 5, 1, 3, 1, 3, 4, 'test', 'test', '', 'N', 0, 0, 0, 0, 0, 0, 1, 1, 3, '1988-01-01', '1988-01-01', 'P', 2),
(44, 'toti', 'toti123', 'toti@hotmail.com', 'toti toti', 'M', 1, '91.232.101.48', '2017-02-24', '2017-02-24', 2, 6, 4, 3, 3, 5, 3, 3, 4, 5, 'ttt', 'try', '', 'N', 0, 0, 0, 0, 0, 0, 1, 1, 4, '1988-01-01', '1988-01-01', 'P', 2),
(45, 'toti', 'toti123', 'toti@hotmail.com', 'toti toti', 'M', 1, '91.232.101.48', '2017-02-24', '2017-02-24', 2, 6, 4, 3, 3, 5, 3, 3, 4, 5, 'ttt', 'try', '', 'N', 0, 0, 0, 0, 0, 0, 1, 1, 4, '1988-01-01', '1988-01-01', 'P', 2),
(46, 'nen1001', 'nen100123', 'nasrnassar14@gmail.com', 'Nasr Nassar', 'M', 1, '5.30.114.156', '2017-02-25', '2017-02-25', 1, 3, 1, 1, 3, 4, 1, 1, 1, 4, 'test self description', 'test partner description', '', 'N', 0, 0, 0, 0, 0, 0, 1, 1, 6, '1988-01-01', '1988-01-01', 'P', 2),
(47, 'jad', 'jad', 'blabla@gmail..com', 'jad abi nader', 'M', 3, '178.135.88.186', '2017-07-16', '2017-07-16', 1, 3, 1, 5, 1, 0, 4, 1, 1, 5, 'beautiful ', 'beautiful ', '', 'N', 0, 0, 0, 0, 0, 0, 1, 1, 3, '1988-01-01', '1988-01-01', 'P', 2),
(48, 'jad', 'jad', 'blabla@gmail..com', 'jad abi nader', 'M', 3, '178.135.88.186', '2017-07-16', '2017-07-16', 1, 3, 1, 5, 1, 0, 4, 1, 1, 5, 'beautiful ', 'beautiful ', '', 'N', 0, 0, 0, 0, 0, 0, 1, 1, 3, '1988-01-01', '1988-01-01', 'P', 2),
(49, 'jad', 'jad', 'blabla@gmail..com', 'jad abi nader', 'M', 3, '178.135.88.186', '2017-07-16', '2017-07-16', 1, 3, 1, 5, 1, 0, 4, 1, 1, 5, 'beautiful ', 'beautiful ', '', 'N', 0, 0, 0, 0, 0, 0, 1, 1, 3, '1988-01-01', '1988-01-01', 'P', 2),
(50, 'jad', 'jad', 'blabla@gmail..com', 'jad abi nader', 'M', 3, '178.135.88.186', '2017-07-16', '2017-07-16', 1, 3, 1, 5, 1, 0, 4, 1, 1, 5, 'beautiful ', 'beautiful ', '', 'N', 0, 0, 0, 0, 0, 0, 1, 1, 3, '1988-01-01', '1988-01-01', 'P', 2),
(51, 'jad', 'jad', 'blabla@gmail..com', 'jad abi nader', 'M', 3, '178.135.88.186', '2017-07-16', '2017-07-16', 1, 3, 1, 5, 1, 0, 4, 1, 1, 5, 'beautiful ', 'beautiful ', '', 'N', 0, 0, 0, 0, 0, 0, 1, 1, 3, '1988-01-01', '1988-01-01', 'P', 2);

-- --------------------------------------------------------

--
-- Table structure for table `ages`
--

CREATE TABLE IF NOT EXISTS `ages` (
  `age_id` int(3) NOT NULL,
  `age_range` varchar(100) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ages`
--

INSERT INTO `ages` (`age_id`, `age_range`) VALUES
(1, '18-22'),
(4, '23-27'),
(5, '28-32'),
(6, '33-37'),
(7, '38-42'),
(8, '43-47'),
(9, '48-52'),
(10, '53-57'),
(11, '58-99'),
(12, '0-18');

-- --------------------------------------------------------

--
-- Table structure for table `available_time`
--

CREATE TABLE IF NOT EXISTS `available_time` (
  `time_frame_id` int(10) NOT NULL,
  `time_frame_desc` varchar(500) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `available_time`
--

INSERT INTO `available_time` (`time_frame_id`, `time_frame_desc`) VALUES
(3, '00:00-04:00'),
(4, '04:00-08:00'),
(5, '08:00-12:00'),
(6, '12:00-04:00'),
(7, '04:00-08:00'),
(8, '08:00-12:00'),
(9, '00:00 - 24:00');

-- --------------------------------------------------------

--
-- Table structure for table `blocks`
--

CREATE TABLE IF NOT EXISTS `blocks` (
  `block_from` int(5) NOT NULL,
  `block_to` int(5) NOT NULL,
  `block_date` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `bulkmessages`
--

CREATE TABLE IF NOT EXISTS `bulkmessages` (
  `message_id` int(10) NOT NULL,
  `subject` varchar(1000) CHARACTER SET utf8 NOT NULL,
  `body` mediumtext CHARACTER SET utf8 NOT NULL,
  `seconds` double NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `card_companies`
--

CREATE TABLE IF NOT EXISTS `card_companies` (
  `company_id` int(2) NOT NULL,
  `company_name` varchar(300) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `card_companies`
--

INSERT INTO `card_companies` (`company_id`, `company_name`) VALUES
(1, 'PayPal'),
(2, 'CashU'),
(3, 'MyCashCash');

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE IF NOT EXISTS `categories` (
  `category_id` int(10) NOT NULL,
  `category_name` varchar(300) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `contact_preferences`
--

CREATE TABLE IF NOT EXISTS `contact_preferences` (
  `account_id` int(10) NOT NULL,
  `way_id` int(3) NOT NULL,
  `way_value` varchar(200) CHARACTER SET utf8 NOT NULL,
  `status` varchar(1) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `contact_ways`
--

CREATE TABLE IF NOT EXISTS `contact_ways` (
  `way_id` int(3) NOT NULL,
  `way_desc_en` varchar(100) CHARACTER SET utf8 NOT NULL,
  `way_desc_ar` varchar(100) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `contact_ways`
--

INSERT INTO `contact_ways` (`way_id`, `way_desc_en`, `way_desc_ar`) VALUES
(1, 'Phone', 'Ù‡Ø§ØªÙ'),
(3, 'Email', 'Ø§Ù„Ø¨Ø±ÙŠØ¯ Ø§Ù„Ø¥Ù„ÙƒØªØ±ÙˆÙ†ÙŠ'),
(4, 'Facebook', 'ÙØ§ÙŠØ³Ø¨ÙˆÙƒ'),
(6, 'Twitter', 'ØªÙˆÙŠØªØ±'),
(7, 'Yahoo Messanger', 'ÙŠØ§Ù‡Ùˆ Ù…Ø³Ù†Ø¬Ø±'),
(8, 'whats up', 'ÙˆØ§ØªØ³ Ø§Ø¨'),
(9, 'skype', 'Ø³ÙƒØ§ÙŠØ¨'),
(10, 'BlackBerry Pin', 'Ø¨Ù„Ø§ÙƒØ¨ÙŠØ±ÙŠ');

-- --------------------------------------------------------

--
-- Table structure for table `countries`
--

CREATE TABLE IF NOT EXISTS `countries` (
  `country_id` int(6) NOT NULL,
  `country_name_en` varchar(200) CHARACTER SET utf8 NOT NULL,
  `country_name_ar` varchar(200) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=27 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `countries`
--

INSERT INTO `countries` (`country_id`, `country_name_en`, `country_name_ar`) VALUES
(1, 'Lebanon', 'Ù„Ø¨Ù†Ø§Ù†'),
(3, 'Saudi Arabia', 'Ø§Ù„Ù…Ù…Ù„ÙƒØ© Ø§Ù„Ø¹Ø±Ø¨ÙŠØ© Ø§Ù„Ø³Ø¹ÙˆØ¯ÙŠØ©'),
(4, 'UAE', 'Ø§Ù„Ø§Ù…Ø§Ø±Ø§Øª Ø§Ù„Ø¹Ø±Ø¨ÙŠØ© Ø§Ù„Ù…ØªØ­Ø¯Ø©'),
(5, 'Qatar', 'Ù‚Ø·Ø±'),
(6, 'Kuwait', 'Ø§Ù„ÙƒÙˆÙŠØª'),
(7, 'Oman', 'Ø³Ù„Ø·Ù†Ø© Ø¹Ù…Ø§Ù†'),
(8, 'Bahrain', 'Ø§Ù„Ø¨Ø­Ø±ÙŠÙ†'),
(9, 'Jordan', 'Ø§Ù„Ø§Ø±Ø¯Ù†'),
(10, 'Maroc', 'Ø§Ù„Ù…ØºØ±Ø¨'),
(11, 'Egypt', 'Ù…ØµØ±'),
(12, 'Tunisie', 'ØªÙˆÙ†Ø³'),
(13, 'Algerie', 'Ø§Ù„Ø¬Ø²Ø§Ø¦Ø±'),
(14, 'Libya', 'Ù„ÙŠØ¨ÙŠØ§'),
(15, 'Irak', 'Ø§Ù„Ø¹Ø±Ø§Ù‚'),
(16, 'Sudan', 'Ø§Ù„Ø³ÙˆØ¯Ø§Ù†'),
(17, 'Syria', 'Ø³ÙˆØ±ÙŠØ§'),
(18, 'Yemen', 'Ø§Ù„ÙŠÙ…Ù†'),
(19, 'Palestine', 'ÙÙ„Ø³Ø·ÙŠÙ†'),
(20, 'Asiancontry', 'Ø¯ÙˆÙ„Ø© Ø¢Ø³ÙŠÙˆÙŠØ©'),
(21, 'European country', 'Ø¯ÙˆÙ„Ø© Ø£ÙˆØ±ÙˆØ¨ÙŠØ©'),
(22, 'American Country', 'Ø¯ÙˆÙ„Ø© Ø£Ù…ÙŠØ±ÙŠÙƒÙŠØ©'),
(23, 'Australia', 'Ø£Ø³ØªØ±Ø§Ù„ÙŠØ§'),
(24, 'Other', 'Ø¯ÙˆÙ„Ø© Ø£Ø®Ø±Ù‰'),
(26, 'Moritania', 'Ù…ÙˆØ±ÙŠØªØ§Ù†ÙŠØ§');

-- --------------------------------------------------------

--
-- Table structure for table `educ_levels`
--

CREATE TABLE IF NOT EXISTS `educ_levels` (
  `educ_level_id` int(5) NOT NULL,
  `educ_level_en` varchar(200) CHARACTER SET utf8 NOT NULL,
  `educ_level_ar` varchar(200) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `educ_levels`
--

INSERT INTO `educ_levels` (`educ_level_id`, `educ_level_en`, `educ_level_ar`) VALUES
(1, 'University Degree', 'ØªØ¹Ù„ÙŠÙ… Ø¬Ø§Ù…Ø¹ÙŠ'),
(3, 'High School', 'ØªØ¹Ù„ÙŠÙ… Ù…Ø¯Ø±Ø³ÙŠ'),
(4, 'High Degrees', 'Ø§Ø®ØªØµØ§ØµØ§Øª Ø¹Ù„ÙŠØ§'),
(5, 'Technical Education', 'ØªØ¹Ù„ÙŠÙ… Ù…Ù‡Ù†ÙŠ'),
(6, 'Not Educated', 'ØºÙŠØ± Ù…ØªØ¹Ù„Ù…');

-- --------------------------------------------------------

--
-- Table structure for table `emails`
--

CREATE TABLE IF NOT EXISTS `emails` (
  `mail_id` int(10) NOT NULL,
  `mail_desc` varchar(200) CHARACTER SET utf8 NOT NULL,
  `category_id` int(10) NOT NULL,
  `mail_seq` int(10) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `eye_colors`
--

CREATE TABLE IF NOT EXISTS `eye_colors` (
  `color_id` int(3) NOT NULL,
  `color_desc_en` varchar(100) CHARACTER SET utf8 NOT NULL,
  `color_desc_ar` varchar(100) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `eye_colors`
--

INSERT INTO `eye_colors` (`color_id`, `color_desc_en`, `color_desc_ar`) VALUES
(1, 'Green', 'Ø£Ø®Ø¶Ø±'),
(2, 'Blue', 'Ø£Ø²Ø±Ù‚'),
(3, 'Black', 'Ø£Ø³ÙˆØ¯'),
(5, 'Brown', 'Ø¨Ù†ÙŠ'),
(8, 'Hazel', 'Ø¹Ø³Ù„ÙŠ'),
(9, 'Other', 'ØºÙŠØ± Ø°Ù„Ùƒ'),
(11, 'Grey', 'Ø±Ù…Ø§Ø¯ÙŠ');

-- --------------------------------------------------------

--
-- Table structure for table `hair_color`
--

CREATE TABLE IF NOT EXISTS `hair_color` (
  `color_id` int(3) NOT NULL,
  `color_desc_en` varchar(100) CHARACTER SET utf8 NOT NULL,
  `color_desc_ar` varchar(100) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `hair_color`
--

INSERT INTO `hair_color` (`color_id`, `color_desc_en`, `color_desc_ar`) VALUES
(3, 'Black', 'Ø£Ø³ÙˆØ¯'),
(5, 'Blonde', 'Ø§Ø´Ù‚Ø±'),
(6, 'Dark Brown', 'ÙƒØ³ØªÙ†Ø§Ø¦ÙŠ'),
(7, 'grey', 'Ø±Ù…Ø§Ø¯ÙŠ'),
(8, 'White', 'Ø§Ø¨ÙŠØ¶'),
(9, 'Other', 'ØºÙŠØ± Ø°Ù„Ùƒ'),
(10, 'Brown', 'Ø¨Ù†ÙŠ'),
(11, 'Red', 'Ø£Ø­Ù…Ø±');

-- --------------------------------------------------------

--
-- Table structure for table `heights`
--

CREATE TABLE IF NOT EXISTS `heights` (
  `height_id` int(3) NOT NULL,
  `height_desc_ar` varchar(100) CHARACTER SET utf8 NOT NULL,
  `height_desc_en` varchar(100) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `heights`
--

INSERT INTO `heights` (`height_id`, `height_desc_ar`, `height_desc_en`) VALUES
(1, 'Ø·ÙˆÙŠÙ„', 'Tall'),
(3, 'Ù‚ØµÙŠØ±', 'Short'),
(4, 'Ù…ØªÙˆØ³Ø·', 'Normal');

-- --------------------------------------------------------

--
-- Table structure for table `images`
--

CREATE TABLE IF NOT EXISTS `images` (
  `image_id` int(10) NOT NULL,
  `image_name` varchar(300) CHARACTER SET utf8 NOT NULL,
  `account_id` int(10) NOT NULL,
  `promoted` varchar(1) CHARACTER SET utf8 NOT NULL,
  `is_profile` varchar(1) CHARACTER SET utf8 NOT NULL,
  `image_status` varchar(1) CHARACTER SET utf8 NOT NULL,
  `promoted_banner` varchar(1) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=116 DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `interests`
--

CREATE TABLE IF NOT EXISTS `interests` (
  `interest_from` int(5) NOT NULL,
  `interest_to` int(5) NOT NULL,
  `interest_date` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `jobs`
--

CREATE TABLE IF NOT EXISTS `jobs` (
  `job_id` int(6) NOT NULL,
  `job_desc_en` varchar(200) CHARACTER SET utf8 NOT NULL,
  `job_desc_ar` varchar(200) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `jobs`
--

INSERT INTO `jobs` (`job_id`, `job_desc_en`, `job_desc_ar`) VALUES
(4, 'Student', 'Ø·Ø§Ù„Ø¨'),
(5, 'Public Sector', 'Ù…ÙˆØ¸Ù Ø­ÙƒÙˆÙ…ÙŠ'),
(6, 'Private Sector', 'Ù…ÙˆØ¸Ù Ù‚Ø·Ø§Ø¹ Ø®Ø§Øµ'),
(7, 'Banking', 'Ù‚Ø·Ø§Ø¹ Ø§Ù„Ù…ØµØ±ÙÙŠ'),
(8, 'Teaching', 'Ù‚Ø·Ø§Ø¹ Ø§Ù„ØªØ¯Ø±ÙŠØ³'),
(9, 'Medical Sector', 'Ø§Ù„Ù‚Ø·Ø§Ø¹ Ø§Ù„Ø·Ø¨ÙŠ'),
(10, 'Journalist', 'ØµØ­ÙÙŠ'),
(11, 'bussines', 'ØªØ¬Ø§Ø±Ø©'),
(12, 'Nothing', 'Ù„Ø§ Ø§Ø¹Ù…Ù„ Ø­Ø§Ù„ÙŠØ§'),
(13, 'Military', 'Ø¹Ø³ÙƒØ±ÙŠ'),
(14, 'Other', 'ØºÙŠØ± Ø°Ù„Ùƒ'),
(15, 'Business Owner', 'ØµØ§Ø­Ø¨ Ø£Ø¹Ù…Ø§Ù„ Ø®Ø§ØµØ©'),
(16, 'Retiree', 'Ù…ØªÙ‚Ø§Ø¹Ø¯');

-- --------------------------------------------------------

--
-- Table structure for table `lastactivity`
--

CREATE TABLE IF NOT EXISTS `lastactivity` (
  `account_id` int(11) NOT NULL,
  `lastactive` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `marital_status`
--

CREATE TABLE IF NOT EXISTS `marital_status` (
  `status_id` int(3) NOT NULL,
  `status_desc_en` varchar(100) NOT NULL,
  `status_desc_ar` varchar(100) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `marital_status`
--

INSERT INTO `marital_status` (`status_id`, `status_desc_en`, `status_desc_ar`) VALUES
(1, 'Married', 'Ù…ØªØ²ÙˆØ¬'),
(3, 'single', 'Ø§Ø¹Ø²Ø¨'),
(4, 'divorsed', 'Ù…Ø·Ù„Ù‚'),
(5, 'widowed', 'Ø§Ø±Ù…Ù„'),
(6, 'engaged', 'Ù…Ø®Ø·ÙˆØ¨'),
(7, 'other', 'ØºÙŠØ± Ø°Ù„Ùƒ');

-- --------------------------------------------------------

--
-- Table structure for table `mass_message`
--

CREATE TABLE IF NOT EXISTS `mass_message` (
  `message_id` int(10) NOT NULL,
  `from_account` int(7) NOT NULL,
  `subject` varchar(1000) CHARACTER SET utf8 NOT NULL,
  `body` varchar(10000) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `messages`
--

CREATE TABLE IF NOT EXISTS `messages` (
  `message_id` int(20) NOT NULL,
  `from_account` int(10) NOT NULL,
  `to_account` int(10) NOT NULL,
  `subject` varchar(2000) CHARACTER SET utf8 NOT NULL,
  `body` mediumtext CHARACTER SET utf8 NOT NULL,
  `message_status` varchar(1) CHARACTER SET utf8 NOT NULL,
  `message_date` date NOT NULL,
  `message_read` varchar(1) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=72 DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `pendingmail`
--

CREATE TABLE IF NOT EXISTS `pendingmail` (
  `mail_id` int(10) NOT NULL,
  `email` varchar(200) CHARACTER SET utf8 NOT NULL,
  `message_id` int(10) NOT NULL,
  `mail_status` varchar(1) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `privacy`
--

CREATE TABLE IF NOT EXISTS `privacy` (
  `privacy_en` mediumtext CHARACTER SET utf8 NOT NULL,
  `privacy_ar` mediumtext CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `privacy`
--

INSERT INTO `privacy` (`privacy_en`, `privacy_ar`) VALUES
('<p>\r\n	under copyright</p>\r\n', '<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	<span style="font-size:20px;"><strong>Ø³ÙŠØ§Ø³Ø© Ø§Ù„Ø®ØµÙˆØµÙŠØ©</strong></span></p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	Ø®Ù„Ù‚ Ø£ØµØ­Ø§Ø¨ Ù‡Ø°Ù‡ Ø§Ù„Ø®Ø¯Ù…Ø© Ø¨ÙŠØ§Ù† Ø§Ù„Ø®ØµÙˆØµÙŠØ© Ù‡Ø°Ø§ (Ø§Ù„Ø³ÙŠØ§Ø³Ø©) Ù…Ù† Ø£Ø¬Ù„ Ø¥Ø¸Ù‡Ø§Ø± Ø§Ù„ØªØ²Ø§Ù…Ù‡Ù… Ø§Ù„Ø«Ø§Ø¨Øª Ù„Ù…Ø³Ø§Ø¹Ø¯Ø© Ø§Ù„Ù…Ø³ØªØ®Ø¯Ù…ÙŠÙ† Ø¹Ù„Ù‰ Ø§Ù„ØªÙÙ‡Ù… Ø¨Ø´ÙƒÙ„ Ø£ÙØ¶Ù„ Ø£ÙŠ Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ù†Ø¬Ù…Ø¹ Ø¹Ù†Ù‡Ù… ØŒ ÙˆÙ…Ø§Ø°Ø§ ÙŠÙ…ÙƒÙ† Ø£Ù† ÙŠØ­Ø¯Ø« Ù„ØªÙ„Ùƒ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª</p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	<span dir="LTR">&nbsp;ahbaab.com </span>ÙŠÙƒØ´Ù Ù„Ù†Ø§ Ø§Ù„ØªØ§Ù„ÙŠ Ø¬Ù…Ø¹ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª ÙˆÙ…Ù…Ø§Ø±Ø³Ø§Øª Ø§Ù„Ù†Ø´Ø±</p>\r\n<p dir="RTL">\r\n	Ù†Ø¸Ø±Ø© Ø¹Ø§Ù…Ø©</p>\r\n<p dir="RTL">\r\n	ÙƒØ¬Ø²Ø¡ Ù…Ù† Ø¹Ù…Ù„ÙŠØ© Ø¹Ø§Ø¯ÙŠØ© Ù…Ù† Ø®Ø¯Ù…Ø§ØªÙ†Ø§ Ù†Ø¬Ù…Ø¹ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª ØŒ ÙˆÙÙŠ Ø¨Ø¹Ø¶ Ø§Ù„Ø­Ø§Ù„Ø§Øª ØŒ Ù‚Ø¯ Ù†ÙƒØ´Ù Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø¹Ù†Ùƒ . Ø³ÙŠØ§Ø³Ø© Ø§Ù„Ø®ØµÙˆØµÙŠØ© Ù‡Ø°Ù‡ ØªØµÙ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„ØªÙŠ Ù†Ø¬Ù…Ø¹Ù‡Ø§ Ø­ÙˆÙ„Ùƒ ÙˆØ­ÙˆÙ„ Ù…Ø§ Ù‚Ø¯ ÙŠØ­Ø¯Ø« Ù„ØªÙ„Ùƒ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª. Ø¨Ù‚Ø¨ÙˆÙ„Ùƒ Ù‡Ø°Ù‡ Ø§Ù„Ø®ØµÙˆØµÙŠØ© ÙˆØ§Ù„Ø§Ø­ÙƒØ§Ù… ÙˆØ§Ù„Ø´Ø±ÙˆØ·ØŒÙØ¥Ù†Ùƒ ØªÙˆØ§ÙÙ‚ Ø¹Ù„Ù‰ Ø§Ø³ØªØ®Ø¯Ø§Ù…Ù†Ø§ ÙˆØ§Ù„ÙƒØ´Ù Ø¹Ù† Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„Ø´Ø®ØµÙŠØ© Ø§Ù„Ø®Ø§ØµØ© Ø¨Ùƒ Ø¹Ù„Ù‰ Ø§Ù„ÙˆØ¬Ù‡ Ø§Ù„Ù…Ø¨ÙŠÙ† ÙÙŠ Ù‡Ø°Ù‡ Ø§Ù„Ø®ØµÙˆØµÙŠØ©.ÙŠØªÙ… ØªØ¶Ù…ÙŠÙ† Ù‡Ø°Ù‡ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª ÙÙŠ Ø³ÙŠØ§Ø³Ø© Ø§Ù„Ø®ØµÙˆØµÙŠØ© ÙˆØªØ®Ø¶Ø¹ Ù„Ø´Ø±ÙˆØ· Ø¨Ù†ÙˆØ¯ ÙˆØ´Ø±ÙˆØ·<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	Ø¨ÙŠØ§Ù† Ø§Ù„Ø®ØµÙˆØµÙŠØ© Ù‡Ø°Ø§ ÙŠÙ†Ø·Ø¨Ù‚ Ø¹Ù„Ù‰ Ø¬Ù…ÙŠØ¹ Ø§Ù„Ù…ÙˆØ§Ù‚Ø¹ Ø°Ø§Øª Ø§Ù„ØµÙ„Ø©. Ø¬Ù…ÙŠØ¹ Ø§Ù„Ù…ÙˆØ§Ù‚Ø¹ Ø§Ù„Ø£Ø®Ø±Ù‰ ÙÙŠ Ø¬Ù…ÙŠØ¹ Ø£Ù†Ø­Ø§Ø¡ Ø§Ù„Ø¹Ø§Ù„Ù… ØªØ¹Ù…Ù„ ÙÙŠ Ø¸Ù„ Ù…Ù…Ø§Ø±Ø³Ø§Øª Ø§Ù„Ø®ØµÙˆØµÙŠØ© Ù…Ù…Ø§Ø«Ù„Ø© ÙƒÙ…Ø§ Ù‡Ùˆ Ù…ÙˆØ¶Ø­ ÙÙŠ Ø³ÙŠØ§Ø³Ø© Ø§Ù„Ø®ØµÙˆØµÙŠØ© Ù‡Ø°Ù‡ ØŒ ÙˆØªØ®Ø¶Ø¹ Ù„Ù…ØªØ·Ù„Ø¨Ø§Øª Ø§Ù„Ù‚Ø§Ù†ÙˆÙ† Ø§Ù„Ù…Ø­Ù„ÙŠ Ø§Ù„Ù…Ø¹Ù…ÙˆÙ„ Ø¨Ù‡ ØŒ ÙˆÙ†Ø­Ù† Ù†Ø³Ø¹Ù‰ Ø¬Ø§Ù‡Ø¯ÙŠÙ† Ù„ØªÙˆÙÙŠØ± Ù…Ø¬Ù…ÙˆØ¹Ø© Ù…ØªÙ†Ø§Ø³Ù‚Ø© Ù…Ù† Ù…Ù…Ø§Ø±Ø³Ø§Øª Ø§Ù„Ø®ØµÙˆØµÙŠØ© ÙÙŠ Ø¬Ù…ÙŠØ¹ Ø£Ù†Ø­Ø§Ø¡ Ù…ÙˆØ§Ù‚Ø¹ Ø´Ø®ØµÙŠØ© Ø¹Ù„Ù‰ Ø§Ù„Ø§Ù†ØªØ±Ù†Øª<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	<span dir="LTR">1. </span>Ù…Ø°ÙƒØ±Ø© Ø®Ø§ØµØ© Ø­ÙˆÙ„ Ø§Ù„Ø£Ø·ÙØ§Ù„</p>\r\n<p dir="RTL">\r\n	Ø§Ù„Ø£Ø·ÙØ§Ù„ Ù„ÙŠØ³ÙˆØ§ Ù…Ø¤Ù‡Ù„ÙŠÙ† Ù„Ù„Ø§Ø³ØªÙØ§Ø¯Ø© Ù…Ù† Ø§Ù„Ø®Ø¯Ù…Ø§Øª Ø§Ù„ØªÙŠ Ù†Ù‚Ø¯Ù…Ù‡Ø§ ØŒ ÙˆÙ†Ø­Ù† Ù†Ø·Ù„Ø¨ Ø£Ù† Ø§Ù„Ù‚ØµØ± (ØªØ­Øª Ø³Ù† 18) Ù„Ø§ ÙŠÙ‚Ø¯Ù… Ø£ÙŠØ© Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø´Ø®ØµÙŠØ© Ù„Ù†Ø§. Ø¥Ø°Ø§ ÙƒÙ†Øª Ù‚Ø§ØµØ±Ø§ ØŒ ÙŠÙ…ÙƒÙ†Ùƒ Ø§Ø³ØªØ®Ø¯Ø§Ù… Ù‡Ø°Ù‡ Ø§Ù„Ø®Ø¯Ù…Ø© ÙÙ‚Ø· Ø¨Ø§Ù„Ø§Ø´ØªØ±Ø§Ùƒ Ù…Ø¹ ÙˆØ§Ù„Ø¯ÙŠÙƒ Ø£Ùˆ Ø£ÙˆÙ„ÙŠØ§Ø¡ Ø£Ù…ÙˆØ±Ù‡Ù…<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	<span dir="LTR">2. </span>Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„ØªÙŠ Ù†Ø¬Ù…Ø¹Ù‡Ø§</p>\r\n<p dir="RTL">\r\n	Ù‡Ø¯ÙÙ†Ø§ Ø§Ù„Ø±Ø¦ÙŠØ³ÙŠ ÙÙŠ Ø¬Ù…Ø¹ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„Ø´Ø®ØµÙŠØ© Ù‡Ùˆ Ø£Ù† Ù†Ù‚Ø¯Ù… Ù„Ùƒ ØªØ¬Ø±Ø¨Ø© Ø³Ù„Ø³Ø© Ùˆ ÙØ¹Ø§Ù„Ø© ØŒ ÙˆÙ‡Ø°Ø§ ÙŠØ³Ù…Ø­ Ù„Ù†Ø§ Ù„ØªÙ‚Ø¯ÙŠÙ… Ø§Ù„Ø®Ø¯Ù…Ø§Øª ÙˆØ§Ù„Ù…ÙŠØ²Ø§Øª Ø§Ù„ØªÙŠ Ø¹Ù„Ù‰ Ø§Ù„Ø£Ø±Ø¬Ø­ ØªÙ„Ø¨ÙŠ Ø§Ø­ØªÙŠØ§Ø¬Ø§ØªÙƒÙ… ÙˆØªØ®ØµÙŠØµ Ø®Ø¯Ù…ØªÙ†Ø§ Ù„Ø¬Ø¹Ù„ ØªØ¬Ø±Ø¨ØªÙƒÙ… Ø£Ø³Ù‡Ù„.Ù‡Ù„ ØªÙˆØ§ÙÙ‚ Ø¹Ù„Ù‰ Ø£Ù† Ù…Ù† Ø£Ø¬Ù„ Ù…Ø³Ø§Ø¹Ø¯Ø© Ø£Ø¹Ø¶Ø§Ø¦Ù†Ø§ Ù„Ù„Ù‚Ø§Ø¡ Ø¨Ø¹Ø¶Ù‡Ù… Ø§Ù„Ø¨Ø¹Ø¶ Ø£Ù†Ù†Ø§ Ù‚Ø¯ Ù†Ø¶Ù… ØªØ´ÙƒÙŠÙ„Ø§Øª Ø§Ù„Ø£Ø¹Ø¶Ø§Ø¡ ÙÙŠ Ø§Ù„Ù†Ø´Ø±Ø§Øª Ø§Ù„Ø¥Ø®Ø¨Ø§Ø±ÙŠØ© Ø§Ù„ØªÙŠ Ù†Ø±Ø³Ù„ Ø¨Ù‡Ø§ Ù…Ù† ÙˆÙ‚Øª Ù„Ø¢Ø®Ø± Ù„Ø£Ø¹Ø¶Ø§Ø¦Ù†Ø§. Ø§Ø³Ù…Ùƒ ÙˆØ¹Ù†ÙˆØ§Ù†Ùƒ ÙˆØ±Ù‚Ù… Ø§Ù„Ù‡Ø§ØªÙ Ù‡ÙŠ Ø³Ø±ÙŠØ© ÙˆÙ„Ù† ÙŠØªÙ… Ù†Ø´Ø±Ù‡Ø§ ÙÙŠ Ø§Ù„ØªØ¹Ø±ÙŠÙ Ø§Ù„Ø®Ø§Øµ Ø¨Ùƒ. Ø§Ù„ØªØ¹Ø±ÙŠÙ Ø§Ù„Ø®Ø§Øµ Ø¨Ùƒ Ù‡Ùˆ Ù…ØªØ§Ø­ Ù„Ù„Ø£Ø¹Ø¶Ø§Ø¡ Ø§Ù„Ø¢Ø®Ø±ÙŠÙ† ÙÙŠ Ø¹Ø±Ø¶Ù‡Ø§. Ù…Ù„Ø§Ù…Ø­ Ø§Ù„Ø£Ø¹Ø¶Ø§Ø¡ ØªØªØ¶Ù…Ù† ÙˆØµÙØ§ ÙˆØ§Ù„ØµÙˆØ± ØŒ ÙˆÙ…Ø§Ø°Ø§ ÙŠØ­Ø¨ ÙˆÙ…Ø§Ø°Ø§ ÙŠÙƒØ±Ù‡ ØŒ ÙˆØ§Ù„Ù…Ù‚Ø§Ù„Ø§Øª Ø§Ù„ÙØ±Ø¯ÙŠØ© ÙˆØºÙŠØ±Ù‡Ø§ Ù…Ù† Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„Ù…ÙÙŠØ¯Ø© ÙÙŠ ØªØ­Ø¯ÙŠØ¯ Ø§Ù„ØªØ·Ø§Ø¨Ù‚ . Ù…Ù„Ù Ø§Ù„ØªØ¹Ø±ÙŠÙ Ø§Ù„Ø®Ø§Øµ Ø¨Ùƒ Ù„Ù„Ø¹Ø±Ø¶ Ù„Ø§ ÙŠØªØ¶Ù…Ù† Ø£ÙŠ Ù…Ø¹Ù„ÙˆÙ…Ø§Øª ØªØ­Ø¯ÙŠØ¯ Ø¹Ù†Ùƒ ØŒ Ù…Ø§ Ø¹Ø¯Ø§ Ø§Ø³Ù… Ø§Ù„Ù…Ø³ØªØ®Ø¯Ù… Ø§Ù„Ø°ÙŠ Ø§Ø®ØªØ±ØªÙ‡ Ø¹Ù†Ø¯ Ø§Ù„ØªØ³Ø¬ÙŠÙ„<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	Ù†Ø­Ù† ØªÙ„Ù‚Ø§Ø¦ÙŠØ§ ØªØ¹Ù‚Ø¨ Ø¨Ø¹Ø¶ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø¹Ù„Ù‰ Ø£Ø³Ø§Ø³ Ø³Ù„ÙˆÙƒÙƒ Ø¹Ù„Ù‰ Ù…ÙˆØ§Ù‚Ø¹Ù†Ø§ Ø¹Ù„Ù‰ Ø§Ù„Ø¥Ù†ØªØ±Ù†Øª Ø¨Ø§Ø³ØªØ®Ø¯Ø§Ù… Ø§Ù„ÙƒÙˆÙƒÙŠØ² ÙˆØºÙŠØ±Ù‡Ø§ Ù…Ù† Ø§Ù„Ø£Ø¬Ù‡Ø²Ø©.Ù†Ø­Ù† Ù†Ø³ØªØ®Ø¯Ù… Ù‡Ø°Ù‡ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ù„Ø£ØºØ±Ø§Ø¶ Ø§Ù„Ø¨Ø­ÙˆØ« Ø§Ù„Ø¯Ø§Ø®Ù„ÙŠØ© Ø¹Ù„Ù‰ Ø§Ù„ØªØ±ÙƒÙŠØ¨Ø© Ø§Ù„Ø³ÙƒØ§Ù†ÙŠØ© Ùˆ Ø£Ø¹Ø¶Ø§Ø¦Ù†Ø§ ØŒ ÙˆØ§Ù„Ù…ØµØ§Ù„Ø­ ØŒ ÙˆØ§Ù„Ø³Ù„ÙˆÙƒ Ù…Ù† Ø£Ø¬Ù„ ÙÙ‡Ù… Ø£ÙØ¶Ù„ ÙˆØ®Ø¯Ù…ØªÙƒÙ… ÙˆØ®Ø¯Ù…Ø© Ù…Ø¬ØªÙ…Ø¹Ù†Ø§.ÙˆÙ‚Ø¯ ØªØ´Ù…Ù„ Ù‡Ø°Ù‡ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª<span dir="LTR"> URL </span>Ø§Ù„Ø°ÙŠ Ø®Ø±Ø¬Øª Ù„Ù„ØªÙˆ Ù…Ù† (Ù…Ø§ Ø¥Ø°Ø§ ÙƒØ§Ù† Ù‡Ø°Ø§ Ø§Ù„Ø¹Ù†ÙˆØ§Ù† Ù‡Ùˆ Ø¹Ù„Ù‰ Ù…ÙˆÙ‚Ø¹Ù†Ø§ Ø£Ùˆ Ù„Ø§<span dir="LTR">). URL </span>Ø§Ù„ØªÙŠ ØªØ°Ù‡Ø¨ Ø¨Ø¬Ø§Ù†Ø¨ (Ù…Ø§ Ø¥Ø°Ø§ ÙƒØ§Ù† Ù‡Ø°Ø§ Ø§Ù„Ø¹Ù†ÙˆØ§Ù† Ù‡Ùˆ Ø¹Ù„Ù‰ Ù…ÙˆÙ‚Ø¹Ù†Ø§ Ø£Ùˆ Ù„Ø§) ØŒ Ù…Ø§ Ø§Ù„Ù…ØªØµÙØ­ Ø§Ù„Ø°ÙŠ ØªØ³ØªØ®Ø¯Ù…Ù‡ ØŒ ÙˆØ¹Ù†ÙˆØ§Ù†<span dir="LTR"> IP </span>Ø§Ù„Ø®Ø§Øµ Ø¨Ùƒ<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	Ù†Ø­Ù† Ù†Ø³ØªØ®Ø¯Ù… Ø£Ø¬Ù‡Ø²Ø© Ø¬Ù…Ø¹ Ø§Ù„Ø¨ÙŠØ§Ù†Ø§Øª Ù…Ø«Ù„ &quot;Ø§Ù„ÙƒÙˆÙƒÙŠØ²&quot; Ø¹Ù„Ù‰ ØµÙØ­Ø§Øª Ù…Ø¹ÙŠÙ†Ø© Ù…Ù† Ù…ÙˆØ§Ù‚Ø¹ Ø§Ù„ÙˆÙŠØ¨ Ù„Ø¯ÙŠÙ†Ø§. &quot;Ø§Ù„ÙƒÙˆÙƒÙŠØ²&quot; Ù‡ÙŠ Ù…Ù„ÙØ§Øª ØµØºÙŠØ±Ø© ØªÙˆØ¶Ø¹ Ø¹Ù„Ù‰ Ø§Ù„Ù‚Ø±Øµ Ø§Ù„ØµÙ„Ø¨ ÙŠÙ…ÙƒÙ† Ø£Ù† ØªØ³Ø§Ø¹Ø¯Ù†Ø§ ÙÙŠ ØªÙ‚Ø¯ÙŠÙ… Ø®Ø¯Ù…Ø§Øª Ù…Ø®ØµØµØ©. ÙƒÙ…Ø§ Ù†Ù‚Ø¯Ù… Ø¨Ø¹Ø¶ Ø§Ù„Ù…ÙŠØ²Ø§Øª Ø§Ù„ØªÙŠ Ù„Ø§ ØªØªÙˆÙØ± Ø¥Ù„Ø§ Ù…Ù† Ø®Ù„Ø§Ù„ Ø§Ø³ØªØ®Ø¯Ø§Ù… &quot;ÙƒÙˆÙƒÙŠ&quot;. Ø§Ù„ÙƒÙˆÙƒÙŠØ² ÙŠÙ…ÙƒÙ† Ø£Ù† ØªØ³Ø§Ø¹Ø¯Ù†Ø§ Ø£ÙŠØ¶Ø§ ØªÙ‚Ø¯ÙŠÙ… Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„ØªÙŠ ØªØ³ØªÙ‡Ø¯Ù Ù…ØµØ§Ù„Ø­ÙƒÙ…. Ù…Ø¹Ø¸Ù… Ù…Ù„ÙØ§Øª ØªØ¹Ø±ÙŠÙ Ø§Ù„Ø§Ø±ØªØ¨Ø§Ø· &quot;ÙƒÙˆÙƒÙŠØ²&quot; ØŒ Ø¨Ù…Ø¹Ù†Ù‰ Ø§Ù† ÙŠØªÙ… Ø­Ø°Ù ØªÙ„Ù‚Ø§Ø¦ÙŠØ§ Ù…Ù† Ø§Ù„Ù‚Ø±Øµ Ø§Ù„ØµÙ„Ø¨ ÙÙŠ Ù†Ù‡Ø§ÙŠØ© Ø§Ù„Ø¯ÙˆØ±Ø©.Ø£Ù†Øª Ø¯Ø§Ø¦Ù…Ø§ Ø­Ø±Ø§ ÙÙŠ Ø±ÙØ¶ Ø§Ù„ÙƒÙˆÙƒÙŠØ² Ù„Ø¯ÙŠÙ†Ø§ Ø¥Ø°Ø§ ÙƒØ§Ù† Ø§Ù„Ù…ØªØµÙØ­ Ø§Ù„Ø®Ø§Øµ Ø¨Ùƒ ÙŠØ³Ù…Ø­ Ù†Ø³ØªØ®Ø¯Ù… Ø·Ø±Ù Ø«Ø§Ù„Ø« Ø´Ø±ÙƒØ© Ø§Ù„Ø§Ø¹Ù„Ø§Ù†Ø§Øª ØŒ Ù„Ø®Ø¯Ù…Ø© Ø§Ù„Ø¥Ø¹Ù„Ø§Ù†Ø§Øª Ù†ÙŠØ§Ø¨Ø© Ø¹Ù†Ø§ Ø¹Ø¨Ø± Ø§Ù„Ø¥Ù†ØªØ±Ù†Øª. ÙŠØ¬ÙˆØ² Ù„Ù„Ø·Ø±Ù Ø«Ø§Ù„Ø« Ø£ÙŠØ¶Ø§ Ø¬Ù…Ø¹ Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ù…Ø¬Ù‡ÙˆÙ„Ø© Ø§Ù„Ù…ØµØ¯Ø± Ø¹Ù† Ø²ÙŠØ§Ø±Ø§ØªÙƒ Ù„Ù…ÙˆÙ‚Ø¹Ù†Ø§<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	<span dir="LTR">3. </span>Ø§Ø³ØªØ®Ø¯Ø§Ù… Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„Ø®Ø§ØµØ© Ø¨Ùƒ</p>\r\n<p dir="RTL">\r\n	Ù†Ø³ØªØ®Ø¯Ù… Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª ÙÙŠ Ø§Ù„Ù…Ù„ÙØ§Øª Ø§Ù„ØªÙŠ Ù†Ø­ÙØ¸Ù‡Ø§ Ù„ÙƒÙ… ØŒ ÙˆØºÙŠØ±Ù‡Ø§ Ù…Ù† Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„ØªÙŠ Ù†Ø­ØµÙ„ Ø¹Ù„ÙŠÙ‡Ø§ Ù…Ù† Ù†Ø´Ø§Ø·Ø§ØªÙƒ Ø§Ù„Ø­Ø§Ù„ÙŠØ© ÙˆØ§Ù„Ø³Ø§Ø¨Ù‚Ø© Ø¹Ù„Ù‰ Ø§Ù„Ù…ÙˆØ§Ù‚Ø¹ Ø§Ù„Ø¥Ù„ÙƒØªØ±ÙˆÙ†ÙŠØ© Ù„ØªØ³ÙˆÙŠØ© Ø§Ù„Ù…Ù†Ø§Ø²Ø¹Ø§Øª ØŒ ÙˆØ§Ø³ØªÙƒØ´Ø§Ù Ø§Ù„Ù…Ø´Ø§ÙƒÙ„ ÙˆÙØ±Ø¶ Ø§Ù„Ø´Ø±ÙˆØ· .ÙÙŠ Ø¨Ø¹Ø¶ Ø§Ù„Ø£Ø­ÙŠØ§Ù† ØŒ Ù‚Ø¯ Ù†Ù†Ø¸Ø± Ø¹Ø¨Ø± Ø£Ø¹Ø¶Ø§Ø¡ Ù…ØªØ¹Ø¯Ø¯Ø© Ù„ØªØ­Ø¯ÙŠØ¯ Ø§Ù„Ù…Ø´Ø§ÙƒÙ„ Ø£Ùˆ Ø­Ù„ Ø§Ù„Ù†Ø²Ø§Ø¹Ø§Øª ØŒ ÙˆØ¨Ø®Ø§ØµØ© Ø£Ù†Ù†Ø§ Ù‚Ø¯ Ù†ÙØ­Øµ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„Ø®Ø§ØµØ© Ø¨Ùƒ Ù„ØªØ­Ø¯ÙŠØ¯ Ø£Ø¹Ø¶Ø§Ø¡ Ù…ØªØ¹Ø¯Ø¯Ø© Ø¹Ø¶Ùˆ Ø±Ù‚Ù… Ø§Ù„ØªØ¹Ø±ÙŠÙ Ø£Ùˆ Ø§Ù„Ø£Ø³Ù…Ø§Ø¡ Ø§Ù„Ù…Ø³ØªØ¹Ø§Ø±Ø©<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	Ø£Ù†Øª ØªÙˆØ§ÙÙ‚ Ø¹Ù„Ù‰ Ø£Ù†Ù†Ø§ Ù‚Ø¯ ØªØ³ØªØ®Ø¯Ù… Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø´Ø®ØµÙŠØ© Ø¹Ù†Ùƒ Ù„ØªØ­Ø³ÙŠÙ† Ø¬Ù‡ÙˆØ¯Ù†Ø§ Ø§Ù„ØªØ³ÙˆÙŠÙ‚ÙŠØ© ÙˆØ§Ù„ØªØ±ÙˆÙŠØ¬ÙŠØ© ØŒ Ù„ØªØ­Ù„ÙŠÙ„ Ø§Ø³ØªØ®Ø¯Ø§Ù… Ø§Ù„Ù…ÙˆÙ‚Ø¹ ØŒ ÙˆØªØ­Ø³ÙŠÙ† Ù…Ø­ØªÙˆÙ‰ ÙˆÙ…Ù†ØªØ¬Ø§Øª ØªÙ‚Ù†ÙŠØ© Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª ØŒ ÙˆØªØ®ØµÙŠØµ Ù…Ø­ØªÙˆÙ‰ Ø§Ù„Ù…ÙˆÙ‚Ø¹ ØŒ ÙˆØ§Ù„ØªØ®Ø·ÙŠØ· ØŒ ÙˆØ§Ù„Ø®Ø¯Ù…Ø§Øª. Ù‡Ø°Ù‡ Ø§Ù„Ø§Ø³ØªØ®Ø¯Ø§Ù…Ø§Øª ØªØ­Ø³Ù† Ù…ÙˆÙ‚Ø¹Ù†Ø§ ÙˆØ²ÙŠØ§Ø¯Ø© ØªÙƒÙŠÙŠÙÙ‡Ø§ Ù„ØªÙ„Ø¨ÙŠØ© Ø§Ø­ØªÙŠØ§Ø¬Ø§ØªÙƒÙ…<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	Ø£Ù†Øª ØªÙˆØ§ÙÙ‚ Ø¹Ù„Ù‰ Ø£Ù†Ù†Ø§ Ù‚Ø¯ Ù†Ø³ØªØ®Ø¯Ù… Ù…Ø¹Ù„ÙˆÙ…Ø§ØªÙƒ Ù„Ù„Ø§ØªØµØ§Ù„ Ø¨Ùƒ ÙˆØªÙ‚Ø¯ÙŠÙ… Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ù„Ùƒ Ø£Ù†Ù‡ ÙÙŠ Ø¨Ø¹Ø¶ Ø§Ù„Ø­Ø§Ù„Ø§Øª ØŒ ØªØ³ØªÙ‡Ø¯Ù Ù…ØµØ§Ù„Ø­ÙƒÙ… ØŒ Ù…Ø«Ù„ Ø´Ø¹Ø§Ø± Ø§Ù„Ø§Ø¹Ù„Ø§Ù†Ø§Øª Ø§Ù„Ù…Ø³ØªÙ‡Ø¯ÙØ© ØŒ ÙˆØ§Ù„Ø¥Ø´Ø¹Ø§Ø±Ø§Øª Ø§Ù„Ø¥Ø¯Ø§Ø±ÙŠØ© ØŒ ÙˆÙ…Ù†ØªØ¬Ø§Øª ØªÙ‚Ù†ÙŠØ© Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª ÙˆØ§Ù„Ø§ØªØµØ§Ù„Ø§Øª Ø°Ø§Øª Ø§Ù„ØµÙ„Ø© Ø¹Ù„Ù‰ Ø§Ø³ØªØ®Ø¯Ø§Ù…Ùƒ Ø¹Ù„Ù‰ Ø§Ù„Ù…ÙˆØ§Ù‚Ø¹. Ù…Ù† Ø®Ù„Ø§Ù„ Ù‚Ø¨ÙˆÙ„ Ø³ÙŠØ§Ø³Ø© Ø§Ù„Ø®ØµÙˆØµÙŠØ© Ù‡Ø°Ù‡ ØŒ ÙØ¥Ù†Ùƒ ØªÙˆØ§ÙÙ‚ ØµØ±Ø§Ø­Ø© Ø¹Ù„Ù‰ ØªÙ„Ù‚ÙŠ Ù‡Ø°Ù‡ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	<span dir="LTR">4. </span>ÙƒØ´Ù Ù…Ø¹Ù„ÙˆÙ…Ø§ØªÙƒ</p>\r\n<p dir="RTL">\r\n	Ø¨Ø³Ø¨Ø¨ Ø§Ù„Ø¨ÙŠØ¦Ø© Ø§Ù„ØªÙ†Ø¸ÙŠÙ…ÙŠØ© Ø§Ù„Ù‚Ø§Ø¦Ù…Ø© ØŒ Ù„Ø§ ÙŠÙ…ÙƒÙ†Ù†Ø§ Ø£Ø¨Ø¯Ø§ Ø¶Ù…Ø§Ù† Ø¬Ù…ÙŠØ¹ Ø§Ù„Ø¨Ù„Ø§ØºØ§Øª Ø§Ù„Ø®Ø§ØµØ© ÙˆØºÙŠØ±Ù‡Ø§ Ù…Ù† Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„Ø´Ø®ØµÙŠØ© Ø£Ù† ÙŠØªÙ… Ø§Ù„ÙƒØ´Ù Ø¹Ù†Ù‡Ø§ Ø¨Ø·Ø±Ù‚ ØºÙŠØ± Ø§Ù„ÙˆØ§Ø±Ø¯ ÙˆØµÙÙ‡Ø§ Ø¥Ù„Ø§ ÙÙŠ Ù‡Ø°Ù‡ Ø§Ù„Ø®ØµÙˆØµÙŠØ©. Ø¹Ù„Ù‰ Ø³Ø¨ÙŠÙ„ Ø§Ù„Ù…Ø«Ø§Ù„ (ÙˆØ¯ÙˆÙ† ØªÙ‚ÙŠÙŠØ¯ Ù…Ø§ Ø³Ø¨Ù‚) ØŒ Ù‚Ø¯ Ù†ÙƒÙˆÙ† Ù…Ø¶Ø·Ø±ÙŠÙ† Ø§Ù„Ù‰ Ø§Ù„ÙƒØ´Ù Ø¹Ù† Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø¥Ù„Ù‰ Ø§Ù„Ø­ÙƒÙˆÙ…Ø© ÙˆÙˆÙƒØ§Ù„Ø§Øª ØªØ·Ø¨ÙŠÙ‚ Ø§Ù„Ù‚Ø§Ù†ÙˆÙ† Ø£Ùˆ Ø£Ø·Ø±Ø§Ù Ø«Ø§Ù„Ø«Ø©.ÙÙŠ Ø¸Ù„ Ø¸Ø±ÙˆÙ Ù…Ø¹ÙŠÙ†Ø© ØŒ Ø£Ø·Ø±Ø§Ù Ø«Ø§Ù„Ø«Ø© Ø¨ØµÙˆØ±Ø© ØºÙŠØ± Ù‚Ø§Ù†ÙˆÙ†ÙŠØ© Ù‚Ø¯ ØªØ¹ØªØ±Ø¶ ÙˆØµÙˆÙ„ Ø§Ù„Ø¥Ø±Ø³Ø§Ù„ Ø£Ùˆ Ø§ØªØµØ§Ù„Ø§Øª Ø®Ø§ØµØ© Ø£Ùˆ Ø£ÙØ±Ø§Ø¯ Ù‚Ø¯ ØªØ±ØªÙƒØ¨ Ø§Ù„ØªØ¹Ø³Ù Ø£Ùˆ Ø¥Ø³Ø§Ø¡Ø© Ø§Ø³ØªØ®Ø¯Ø§Ù… Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„Ø®Ø§ØµØ© Ø¨Ùƒ Ø§Ù„ØªÙŠ ÙŠØ¬Ù…Ø¹ÙˆÙ†Ù‡Ø§ Ù…Ù† Ù…ÙˆØ§Ù‚Ø¹Ù†Ø§ Ø¹Ù„Ù‰ Ø§Ù„Ø¥Ù†ØªØ±Ù†Øª.Ù„Ø°Ø§ ØŒ Ø¹Ù„Ù‰ Ø§Ù„Ø±ØºÙ… Ù…Ù† Ø£Ù†Ù†Ø§ Ù†Ø³ØªØ®Ø¯Ù… Ø§Ù„Ù…Ù…Ø§Ø±Ø³Ø§Øª Ø§Ù„ØµÙ†Ø§Ø¹ÙŠØ© Ø§Ù„Ù‚ÙŠØ§Ø³ÙŠØ© Ù„Ø­Ù…Ø§ÙŠØ© Ø®ØµÙˆØµÙŠØªÙƒ ØŒ ÙˆÙ†Ø­Ù† Ù„Ø§ Ù†Ø¹Ø¯ ØŒ ÙˆÙŠØ¬Ø¨ Ø£Ù† Ù„Ø§ Ù†ØªÙˆÙ‚Ø¹ Ø£Ù† Ù…Ø¹Ù„ÙˆÙ…Ø§ØªÙƒ Ø§Ù„Ø´Ø®ØµÙŠØ© Ø£Ùˆ Ø§Ù„Ø§ØªØµØ§Ù„Ø§Øª Ø§Ù„Ø®Ø§ØµØ© Ø³ØªØ¨Ù‚Ù‰ Ø¯Ø§Ø¦Ù…Ø§ Ø®Ø§ØµØ©<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	ÙƒÙ…Ø³Ø£Ù„Ø© Ø³ÙŠØ§Ø³Ø© ØŒ ÙˆÙ†Ø­Ù† Ù„Ø§ Ù†Ù‚ÙˆÙ… Ø¨Ø¨ÙŠØ¹ Ø£Ùˆ ØªØ£Ø¬ÙŠØ± Ø£ÙŠ Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø´Ø®ØµÙŠØ© Ø¹Ù†Ùƒ Ø¥Ù„Ù‰ Ø£ÙŠ Ø·Ø±Ù Ø«Ø§Ù„Ø«.ÙˆÙ…Ø¹ Ø°Ù„Ùƒ ØŒ Ø§Ù„ØªØ§Ù„ÙŠ ÙŠØµÙ Ø¨Ø¹Ø¶ Ø§Ù„Ø·Ø±Ù‚ Ø§Ù„ØªÙŠ Ù‚Ø¯ ÙŠØªÙ… Ø§Ù„ÙƒØ´Ù Ø¹Ù† Ù…Ø¹Ù„ÙˆÙ…Ø§ØªÙƒ Ø§Ù„Ø´Ø®ØµÙŠØ©<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	Ø§Ù„Ù…Ø¹Ù„Ù†ÙŠÙ†<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	Ù†Ø­Ù† Ù†Ø¬Ù…Ø¹ (Ø¬Ù…Ø¹ Ø§Ù„Ø¨ÙŠØ§Ù†Ø§Øª Ø§Ø­ØªÙŠØ§Ø·ÙŠØ§ Ø¹Ø¨Ø± Ø­Ø³Ø§Ø¨Ø§Øª Ø£Ø¹Ø¶Ø§Ø¦Ù†Ø§ Ø¬Ù…ÙŠØ¹) Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„Ø´Ø®ØµÙŠØ© ÙˆØ§Ù„ÙƒØ´Ù Ø¹Ù† Ù‡Ø°Ù‡ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø¨Ø·Ø±ÙŠÙ‚Ø© ØºÙŠØ± Ø´Ø®ØµÙŠØ© Ø¥Ù„Ù‰ Ø§Ù„Ù…Ø¹Ù„Ù†ÙŠÙ† ÙˆØ£Ø·Ø±Ø§Ù Ø«Ø§Ù„Ø«Ø© Ø£Ø®Ø±Ù‰ Ù„Ù„ØªØ³ÙˆÙŠÙ‚ ÙˆØºÙŠØ±Ù‡Ø§ Ù…Ù† Ø§Ù„Ø£ØºØ±Ø§Ø¶ Ø§Ù„ØªØ±ÙˆÙŠØ¬ÙŠØ©.ÙˆÙ…Ø¹ Ø°Ù„Ùƒ ØŒ ÙÙŠ Ù‡Ø°Ù‡ Ø§Ù„Ø­Ø§Ù„Ø§Øª ØŒ Ù†Ø­Ù† Ù„Ø§ Ù†ÙƒØ´Ù Ù„Ù‡Ø°Ù‡ Ø§Ù„ÙƒÙŠØ§Ù†Ø§Øª Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„ØªÙŠ ÙŠÙ…ÙƒÙ† Ø§Ø³ØªØ®Ø¯Ø§Ù…Ù‡Ø§ ÙÙŠ Ø§Ù„ØªØ¹Ø±Ù Ø¹Ù„ÙŠÙƒ Ø´Ø®ØµÙŠØ§. Ø¨Ø¹Ø¶ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª ØŒ Ù…Ø«Ù„ Ø§Ø³Ù…Ùƒ ÙˆØ¹Ù†ÙˆØ§Ù† Ø§Ù„Ø¨Ø±ÙŠØ¯ Ø§Ù„Ø§Ù„ÙƒØªØ±ÙˆÙ†ÙŠ ØŒ ÙƒÙ„Ù…Ø© Ø§Ù„Ø³Ø± ØŒ Ø±Ù‚Ù… Ø¨Ø·Ø§Ù‚Ø© Ø§Ù„Ø§Ø¦ØªÙ…Ø§Ù† ÙˆØ±Ù‚Ù… Ø§Ù„Ø­Ø³Ø§Ø¨ Ø§Ù„Ù…ØµØ±ÙÙŠ ØŒÙ„ÙŠØ³Øª Ù…ØªØ§Ø­Ø© Ù„Ù…Ø¹Ù„Ù†ÙŠÙ† Ø§Ù„ØªØ³ÙˆÙŠÙ‚ . Ù‚Ø¯ Ù†Ø³ØªØ®Ø¯Ù… Ø´Ø±ÙƒØ§Øª Ø§Ù„Ø§Ø¹Ù„Ø§Ù† Ù…Ù† Ø·Ø±Ù Ø«Ø§Ù„Ø« Ù„Ø®Ø¯Ù…Ø© Ø§Ù„Ø¥Ø¹Ù„Ø§Ù†Ø§Øª Ù†ÙŠØ§Ø¨Ø© Ø¹Ù†Ø§.Ù‚Ø¯ ØªÙƒÙˆÙ† Ù‡Ø°Ù‡ Ø§Ù„Ø´Ø±ÙƒØ§Øª ØªÙˆØ¸Ù Ø§Ù„ÙƒÙˆÙƒÙŠØ² ÙˆØ§Ù„Ø¹Ù…Ù„ Ø¨Ù‡ (ÙˆØ§Ù„ØªÙŠ ØªØ¹Ø±Ù Ø£ÙŠØ¶Ø§ Ø¨Ø§Ø³Ù… ØºÙŠÙØ³ Ø¨ÙƒØ³Ù„ Ø¬ÙØªØ³ Ø£Ùˆ Ù…Ù†Ø§Ø±Ø§Øª Ø§Ù„ÙˆÙŠØ¨) Ù„Ù‚ÙŠØ§Ø³ ÙØ¹Ø§Ù„ÙŠØ© Ø§Ù„Ø¥Ø¹Ù„Ø§Ù†. Ø£ÙŠ Ù…Ø¹Ù„ÙˆÙ…Ø§Øª ØªÙÙŠØ¯ Ø¨Ø£Ù† Ù‡Ø°Ù‡ Ø§Ù„Ø£Ø·Ø±Ø§Ù Ø§Ù„Ø«Ø§Ù„Ø«Ø© Ø¹Ù† Ø·Ø±ÙŠÙ‚ Ø¬Ù…Ø¹ Ø§Ù„ÙƒÙˆÙƒÙŠØ² ÙˆØ§Ù„Ø¹Ù…Ù„ Ø¨Ù‡ Ù‡Ùˆ Ù…Ø¬Ù‡ÙˆÙ„ ØªÙ…Ø§Ù…Ø§<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	Ù…Ù‚Ø¯Ù…ÙŠ Ø§Ù„Ø®Ø¯Ù…Ø© Ø§Ù„Ø®Ø§Ø±Ø¬ÙŠØ©<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	Ù‚Ø¯ ÙŠÙƒÙˆÙ† Ù‡Ù†Ø§Ùƒ Ø¹Ø¯Ø¯ Ù…Ù† Ø§Ù„Ø®Ø¯Ù…Ø§Øª Ø§Ù„Ù…Ù‚Ø¯Ù…Ø© Ù…Ù† Ù‚Ø¨Ù„ Ù…Ù‚Ø¯Ù…ÙŠ Ø§Ù„Ø®Ø¯Ù…Ø© Ø§Ù„Ø®Ø§Ø±Ø¬ÙŠØ© Ø§Ù„ØªÙŠ ØªØ³Ø§Ø¹Ø¯Ùƒ Ø¹Ù„Ù‰ Ø§Ø³ØªØ®Ø¯Ø§Ù… Ø§Ù„Ù…ÙˆØ§Ù‚Ø¹ Ù„Ø¯ÙŠÙ†Ø§. Ø¥Ø°Ø§ Ø§Ø®ØªØ±Øª Ø§Ø³ØªØ®Ø¯Ø§Ù… Ù‡Ø°Ù‡ Ø§Ù„Ø®Ø¯Ù…Ø§Øª Ø§Ù„Ø§Ø®ØªÙŠØ§Ø±ÙŠØ© ØŒ ÙˆØ®Ù„Ø§Ù„ Ù‚ÙŠØ§Ù…Ùƒ Ø¨Ø°Ù„Ùƒ ØŒÙŠÙ…ÙƒÙ†Ùƒ Ø¹Ø¯Ù… Ø§Ù„ÙƒØ´Ù Ø¹Ù† Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ù„Ù…Ù‚Ø¯Ù…ÙŠ Ø§Ù„Ø®Ø¯Ù…Ø§Øª Ø§Ù„Ø®Ø§Ø±Ø¬ÙŠØ© Ùˆ / Ø£Ùˆ Ù…Ù†Ø­Ù‡Ù… Ø¥Ø°Ù† Ù„Ø¬Ù…Ø¹ Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø¹Ù†Ùƒ ØŒ Ø¹Ù†Ø¯Ù‡Ø§ ØŒ Ø§Ø³ØªØ®Ø¯Ø§Ù…Ù‡Ù… Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§ØªÙƒ ÙŠØ®Ø¶Ø¹ Ù„Ø³ÙŠØ§Ø³ØªÙ‡Ø§ Ø§Ù„Ø®Ø§ØµØ©<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	Ø´Ø±ÙƒØ© ÙƒÙŠØ§Ù†Ø§Øª Ø£Ø®Ø±Ù‰<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	Ù†ØªØ´Ø§Ø·Ø± Ø§Ù„ÙƒØ«ÙŠØ± Ù…Ù† Ø§Ù„Ø¨ÙŠØ§Ù†Ø§Øª Ø§Ù„Ù…ØªÙˆÙØ±Ø© Ù„Ø¯ÙŠÙ†Ø§ ØŒ Ø¨Ù…Ø§ ÙÙŠ Ø°Ù„Ùƒ Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø´Ø®ØµÙŠØ© Ø¹Ù†Ùƒ ØŒ Ù…Ø¹ Ø´Ø±ÙƒØªÙ†Ø§ Ø§Ù„Ø£Ù… Ùˆ / Ø£Ùˆ Ø§Ù„Ø´Ø±ÙƒØ§Øª Ø§Ù„ØªØ§Ø¨Ø¹Ø© Ø§Ù„ØªÙŠ ØªÙ„ØªØ²Ù… Ø®Ø¯Ù…Ø© Ø§Ø­ØªÙŠØ§Ø¬Ø§ØªÙƒ Ø§Ù„Ø®Ø§ØµØ© Ø¹Ù„Ù‰ Ø§Ù„Ø§Ù†ØªØ±Ù†Øª ÙˆØ§Ù„Ø®Ø¯Ù…Ø§Øª Ø§Ù„Ù…Ø±ØªØ¨Ø·Ø© Ø¨Ù‡Ø§ ØŒ ÙÙŠ Ø¬Ù…ÙŠØ¹ Ø£Ù†Ø­Ø§Ø¡ Ø§Ù„Ø¹Ø§Ù„Ù….Ø¥Ù„Ù‰ Ø­Ø¯ Ø£Ù† Ù‡Ø°Ù‡ Ø§Ù„ÙƒÙŠØ§Ù†Ø§Øª ÙŠÙ…ÙƒÙ†Ù‡Ø§ Ø§Ù„Ø­ØµÙˆÙ„ Ø¹Ù„Ù‰ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„Ø®Ø§ØµØ© Ø¨Ùƒ ØŒ Ø³ÙˆÙ ÙŠØ¹Ø§Ù…Ù„ÙˆÙ† Ø¨Ù‚Ø¯Ø± Ù…Ù† Ø§Ù„Ø­Ù…Ø§ÙŠØ© Ø­ÙŠØ« ÙŠØªØ¹Ø§Ù…Ù„ÙˆÙ† Ù…Ø¹ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„ØªÙŠ ÙŠØ­ØµÙ„ÙˆÙ† Ø¹Ù„ÙŠÙ‡Ø§ Ù…Ù† Ø£Ø¹Ø¶Ø§Ø¦Ù‡Ø§ Ø§Ù„Ø®Ø§ØµØ© .Ø§Ù„Ø´Ø±ÙƒØ© Ø§Ù„Ø£Ù… Ùˆ / Ø£Ùˆ Ø´Ø±ÙƒØ§ØªÙ‡Ø§ Ø³ÙˆÙ ÙŠØªØ¨Ø¹ÙˆÙ† Ù…Ù…Ø§Ø±Ø³Ø§Øª Ø§Ù„Ø®ØµÙˆØµÙŠØ© Ù„ÙŠØ³Øª Ø£Ù‚Ù„ ÙˆØ§Ù‚ÙŠØ© Ù…Ù† Ø¬Ù…ÙŠØ¹ Ø§Ù„Ø£Ø¹Ø¶Ø§Ø¡ ÙÙŠ Ù…Ù…Ø§Ø±Ø³Ø§ØªÙ†Ø§ Ø§Ù„Ù…ÙˆØµÙˆÙØ© ÙÙŠ Ù‡Ø°Ù‡ Ø§Ù„ÙˆØ«ÙŠÙ‚Ø© ØŒ Ø¨Ø§Ù„Ù‚Ø¯Ø± Ø§Ù„Ø°ÙŠ ÙŠØ³Ù…Ø­ Ø¨Ù‡ Ø§Ù„Ù‚Ø§Ù†ÙˆÙ† Ø§Ù„Ù…Ø¹Ù…ÙˆÙ„ Ø¨Ù‡. ÙÙ…Ù† Ø§Ù„Ù…Ù…ÙƒÙ† Ø£Ù† Ù†Ø­Ù† Ùˆ / Ø£Ùˆ Ø´Ø±ÙƒØ§ØªÙ‡Ø§ Ø§Ù„ØªØ§Ø¨Ø¹Ø© ØŒ Ø£Ùˆ Ø£ÙŠ ØªØ±ÙƒÙŠØ¨Ø© Ù…Ù† Ù‡Ø°Ø§ Ø§Ù„Ù‚Ø¨ÙŠÙ„ ØŒ ÙŠÙ…ÙƒÙ† Ø£Ù† ØªÙ†Ø¯Ù…Ø¬ Ù…Ø¹ Ø£Ùˆ ÙÙŠ Ø­Ø§Ù„ Ø§Ù„Ø­ØµÙˆÙ„ Ù„Ø£Ø­Ø¯ Ø¹Ù„ÙŠÙ†Ø§ ÙƒÙƒÙŠØ§Ù† Ø¹Ù…Ù„ Ø¢Ø®Ø± ØŒ ÙÙŠ Ø­Ø§Ù„ Ø­ØµÙˆÙ„ Ù‡ÙƒØ°Ø§ Ø¬Ù…Ø¹ ØŒ ÙŠØ¬Ø¨ Ø£Ù† ØªØªÙˆÙ‚Ø¹ Ø§Ù†Ù†Ø§ Ø³ÙˆÙ Ù†Ø´Ø§Ø·Ø± Ø¨Ø¹Ø¶ Ø£Ùˆ ÙƒØ§Ù…Ù„ Ù…Ø¹Ù„ÙˆÙ…Ø§ØªÙƒ Ù…Ù† Ø£Ø¬Ù„ Ø§Ù„Ø§Ø³ØªÙ…Ø±Ø§Ø± ÙÙŠ ØªÙ‚Ø¯ÙŠÙ… Ø§Ù„Ø®Ø¯Ù…Ø©. ÙˆØ³ÙˆÙ ØªØªÙ„Ù‚Ù‰ Ø¥Ø´Ø¹Ø§Ø±Ø§ Ø¨Ù‡ÙƒØ°Ø§ Ø­Ø¯Ø« (Ø¨Ø§Ù„Ù‚Ø¯Ø± Ø§Ù„Ø°ÙŠ ÙŠØ­Ø¯Ø«) ÙˆÙ†Ø­Ù† Ø³ÙˆÙ ØªØªØ·Ù„Ø¨ Ù…Ù† Ø§Ù„ÙƒÙŠØ§Ù† Ø§Ù„Ù…Ø¬Ù…ÙˆØ¹ Ø§Ù„Ø¬Ø¯ÙŠØ¯ Ù…ØªØ§Ø¨Ø¹Ø© Ø§Ù„Ù…Ù…Ø§Ø±Ø³Ø§Øª Ø§Ù„ØªÙŠ Ø£ÙØµØ­ Ø¹Ù†Ù‡Ø§ ÙÙŠ Ø³ÙŠØ§Ø³Ø© Ø§Ù„Ø®ØµÙˆØµÙŠØ© Ù‡Ø°Ù‡<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	Ù…ØªØ·Ù„Ø¨Ø§Øª Ø§Ù„Ù‚Ø§Ù†ÙˆÙ†ÙŠØ©<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	Ù†Ø­Ù† ØªØªØ¹Ø§ÙˆÙ† Ù…Ø¹ Ù…Ø§ ÙŠØ·Ù„Ø¨Ù‡ ØªØ·Ø¨ÙŠÙ‚ Ø§Ù„Ù‚Ø§Ù†ÙˆÙ† Ù…Ù† ØªØ­Ù‚ÙŠÙ‚Ø§Øª ØŒ ÙØ¶Ù„Ø§ Ø¹Ù† Ø£Ø·Ø±Ø§Ù Ø£Ø®Ø±Ù‰ Ù„ØªØ·Ø¨ÙŠÙ‚ Ø§Ù„Ù‚ÙˆØ§Ù†ÙŠÙ† ØŒ Ù…Ø«Ù„ : Ø­Ù‚ÙˆÙ‚ Ø§Ù„Ù…Ù„ÙƒÙŠØ© Ø§Ù„ÙÙƒØ±ÙŠØ© ØŒ ÙˆØ§Ù„Ø§Ø­ØªÙŠØ§Ù„ ÙˆØºÙŠØ±Ù‡Ø§ Ù…Ù† Ø§Ù„Ø­Ù‚ÙˆÙ‚. ÙŠÙ…ÙƒÙ†Ù†Ø§ (ÙˆØªØ®ÙˆÙ„ÙˆÙ†Ø§) Ø§Ù„ÙƒØ´Ù Ø¹Ù† Ø£ÙŠØ© Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø¹Ù†Ùƒ Ù„ØªØ·Ø¨ÙŠÙ‚ Ø§Ù„Ù‚Ø§Ù†ÙˆÙ† ÙˆØºÙŠØ±Ù‡Ù… Ù…Ù† Ø§Ù„Ù…Ø³Ø¤ÙˆÙ„ÙŠÙ† Ø§Ù„Ø­ÙƒÙˆÙ…ÙŠÙŠÙ† ÙˆÙ†Ø­Ù† ØŒ ÙÙŠ ØªÙ‚Ø¯ÙŠØ±Ù†Ø§ ØŒ Ø±Ø£ÙŠÙ†Ø§ Ù…Ù† Ø§Ù„Ø¶Ø±ÙˆØ±ÙŠ Ø£Ùˆ Ø§Ù„Ù…Ù†Ø§Ø³Ø¨ ØŒ ÙÙŠ Ø¥Ø·Ø§Ø± ØªØ­Ù‚ÙŠÙ‚ ÙÙŠ Ø§Ù„Ø§Ø­ØªÙŠØ§Ù„ ØŒ ÙˆØ§Ù†ØªÙ‡Ø§ÙƒØ§Øª Ø­Ù‚ÙˆÙ‚ Ø§Ù„Ù…Ù„ÙƒÙŠØ© Ø§Ù„ÙÙƒØ±ÙŠØ© ØŒ Ø£Ùˆ Ø£ÙŠ Ù†Ø´Ø§Ø· Ø¢Ø®Ø± ØºÙŠØ± Ø´Ø±Ø¹ÙŠ Ø£Ùˆ Ù‚Ø¯ ÙŠØ¹Ø±Ø¶ Ù„Ù†Ø§ Ø£Ùˆ Ù„ÙƒÙ… Ù„Ù„Ù…Ø³Ø¤ÙˆÙ„ÙŠØ© Ø§Ù„Ù‚Ø§Ù†ÙˆÙ†ÙŠØ©<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	<span dir="LTR">5. </span>Ø§Ø³ØªØ®Ø¯Ø§Ù… Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„Ø®Ø§ØµØ© Ø¨Ø§Ù„Ø£Ø¹Ø¶Ø§Ø¡ Ø§Ù„Ø¢Ø®Ø±ÙŠÙ†</p>\r\n<p dir="RTL">\r\n	Ø®Ø¯Ù…Ø§ØªÙ†Ø§ ØªØ´Ù…Ù„ Ø£ÙŠØ¶Ø§ Ø§Ù„Ø­ØµÙˆÙ„ Ø¹Ù„Ù‰ Ø§Ù„Ø±Ø³Ø§Ø¦Ù„ Ø§Ù„ÙÙˆØ±ÙŠØ© ÙˆØºØ±Ù Ø§Ù„Ø¯Ø±Ø¯Ø´Ø©. ÙƒØ¹Ø¶Ùˆ Ù„Ø¯ÙŠÙƒ Ø­Ù‚ Ø§Ù„ÙˆØµÙˆÙ„ Ø¥Ù„Ù‰ Ø±Ù‚Ù… Ù‡ÙˆÙŠØ© Ø§Ù„Ø¹Ø¶ÙˆØŒ ÙˆØ±Ø¨Ù…Ø§ ÙŠÙ…ÙƒÙ†Ùƒ Ø§Ù„ÙˆØµÙˆÙ„ Ø¥Ù„Ù‰ Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„Ø§ØªØµØ§Ù„ Ø§Ù„Ø£Ø®Ø±Ù‰ Ù…Ù† Ø§Ù„Ø£Ø¹Ø¶Ø§Ø¡ (Ù‚) Ù…Ù† Ø®Ù„Ø§Ù„ Ø§Ù„Ø§Ø³ØªØ®Ø¯Ø§Ù… Ø§Ù„Ù…Ù†ØªØ¸Ù… Ù„Ù…Ø±Ø§Ø³Ù„Ø© Ø§Ù„ÙÙˆØ±ÙŠØ© ÙˆØºØ±Ù Ø§Ù„Ø¯Ø±Ø¯Ø´Ø©.Ù…Ù† Ø®Ù„Ø§Ù„ Ù‚Ø¨ÙˆÙ„ Ø³ÙŠØ§Ø³Ø© Ø§Ù„Ø®ØµÙˆØµÙŠØ© Ù‡Ø°Ù‡ ØŒ ÙØ¥Ù†Ùƒ ØªÙˆØ§ÙÙ‚ Ø¹Ù„Ù‰ Ø£Ù†Ù‡ ØŒ ÙÙŠÙ…Ø§ ÙŠØªØ¹Ù„Ù‚ Ø¨Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„Ø£Ø¹Ø¶Ø§Ø¡ Ø§Ù„Ø¢Ø®Ø±ÙŠÙ† Ø§Ù„Ø´Ø®ØµÙŠØ© Ø§Ù„ØªÙŠ ØªØ­ØµÙ„ Ø¹Ù„ÙŠÙ‡Ø§ Ù…Ù† Ø®Ù„Ø§Ù„ Ø§Ù„Ø§ØªØµØ§Ù„Ø§Øª ÙˆØ§Ù„Ø±Ø³Ø§Ø¦Ù„ Ø§Ù„ÙÙˆØ±ÙŠØ© ØŒ ÙˆØºØ±Ù Ø§Ù„Ø¯Ø±Ø¯Ø´Ø© ÙˆØ§Ù„Ø¨Ø±ÙŠØ¯ Ø§Ù„Ø¥Ù„ÙƒØªØ±ÙˆÙ†ÙŠ ØŒ Ù†Ø­Ù† Ù‡Ù†Ø§ Ù†Ù…Ù†Ø­Ùƒ ØªØ±Ø®ÙŠØµ Ù„Ø§Ø³ØªØ®Ø¯Ø§Ù… Ù…Ø«Ù„ Ù‡Ø°Ù‡ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª ÙÙ‚Ø· Ù…Ù† Ø£Ø¬Ù„ : (Ø£) Ø´Ø±ÙƒØ© Ø§Ù„Ø§ØªØµØ§Ù„Ø§Øª Ø°Ø§Øª Ø§Ù„ØµÙ„Ø© Ø§Ù„ØªÙŠ Ù‡ÙŠ Ù„ÙŠØ³Øª Ø±Ø³Ø§Ø¦Ù„ ØªØ¬Ø§Ø±ÙŠØ© ØºÙŠØ± Ù…Ø±ØºÙˆØ¨ ÙÙŠÙ‡Ø§ ØŒ Ùˆ (Ø¨) Ù„Ø£ÙŠ ØºØ±Ø¶ Ù…Ù† Ø§Ù„Ø£ØºØ±Ø§Ø¶ Ø§Ù„Ø£Ø®Ø±Ù‰ Ø§Ù„ØªÙŠ ÙŠÙˆØ§ÙÙ‚ Ù‡Ø¤Ù„Ø§Ø¡ Ø§Ù„Ø£Ø¹Ø¶Ø§Ø¡ Ø¹Ù„ÙŠÙ‡Ø§ Ø¨Ø¹Ø¯ Ø§Ù„ÙƒØ´Ù Ø§Ù„ÙƒØ§ÙÙŠ Ù„Ù‡Ø°Ø§ Ø§Ù„ØºØ±Ø¶ . ÙÙŠ Ø¬Ù…ÙŠØ¹ Ø§Ù„Ø­Ø§Ù„Ø§Øª ØŒ ÙŠØ¬Ø¨ Ø¹Ù„ÙŠÙƒ Ø¥Ø¹Ø·Ø§Ø¡ Ø§Ù„Ø£Ø¹Ø¶Ø§Ø¡ ÙØ±ØµØ© Ù„Ø¥Ø²Ø§Ù„Ø© Ø£Ù†ÙØ³Ù‡Ù… Ù…Ù† Ù‚Ø§Ø¹Ø¯Ø© Ø§Ù„Ø¨ÙŠØ§Ù†Ø§Øª Ø§Ù„Ø®Ø§ØµØ© Ø¨Ùƒ ÙˆÙØ±ØµØ© Ù„Ø§Ø³ØªØ¹Ø±Ø§Ø¶ Ù…Ø§ Ù‡ÙŠ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„ØªÙŠ ØªÙ… Ø¬Ù…Ø¹Ù‡Ø§ Ø¹Ù†Ù‡Ù…. Ø¨Ø§Ù„Ø¥Ø¶Ø§ÙØ© Ø¥Ù„Ù‰ Ø°Ù„Ùƒ ØŒ ØªØ­Øª Ø£ÙŠ Ø¸Ø±Ù Ù…Ù† Ø§Ù„Ø¸Ø±ÙˆÙ ØŒ Ø¥Ù„Ø§ ÙƒÙ…Ø§ Ù‡Ùˆ Ù…Ø­Ø¯Ø¯ ÙÙŠ Ù‡Ø°Ø§ Ø§Ù„Ù‚Ø³Ù… ØŒ ÙŠÙ…ÙƒÙ†Ùƒ Ø§Ù„ÙƒØ´Ù Ø¹Ù† Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø´Ø®ØµÙŠØ© Ø¹Ù† Ø¹Ø¶Ùˆ Ø¢Ø®Ø± Ø¥Ù„Ù‰ Ø£ÙŠ Ø·Ø±Ù Ø«Ø§Ù„Ø« Ù…Ù† Ø¯ÙˆÙ† Ù…ÙˆØ§ÙÙ‚ØªÙ†Ø§ ÙˆÙ…ÙˆØ§ÙÙ‚Ø© Ø£Ø¹Ø¶Ø§Ø¡ Ø£Ø®Ø±Ù‰ Ù…Ù† Ù‡Ø°Ø§ Ø§Ù„Ù‚Ø¨ÙŠÙ„ Ø¨Ø¹Ø¯ Ø§Ù„ÙƒØ´Ù Ø§Ù„ÙƒØ§ÙÙŠ<span dir="LTR">. ahbaab.com </span>ÙˆØ£Ø¹Ø¶Ø§Ø¦Ù†Ø§ Ù„Ø§ Ù†Ù‚Ø¨Ù„ Ø§Ù„Ø³Ø¨Ø§Ù… . ÙˆÙ„Ø°Ù„Ùƒ ØŒ Ù…Ù† Ø¯ÙˆÙ† ØªØ­Ø¯ÙŠØ¯ Ù…Ø§ Ø³Ø¨ ØºÙŠØ± Ù…Ø±Ø®Øµ Ù„Ùƒ Ø¨Ø¥Ø¶Ø§ÙØ© Ø¹Ø¶ÙˆØ§ Ù…Ù† Ø¨ ØªÙˆ Ø¥Ù„Ù‰ Ù‚Ø§Ø¦Ù…Ø© Ø§Ù„Ø¨Ø±ÙŠØ¯ Ø§Ù„Ø®Ø§ØµØ© Ø¨Ùƒ (Ø§Ù„Ø¨Ø±ÙŠØ¯ Ø§Ù„Ø¥Ù„ÙƒØªØ±ÙˆÙ†ÙŠ Ø£Ùˆ Ø§Ù„Ù…Ø§Ø¯ÙŠ) Ø¯ÙˆÙ† Ù…ÙˆØ§ÙÙ‚Ø© ØµØ±ÙŠØ­Ø© Ù…Ù†Ù‡Ø§ Ù…ÙƒØªÙˆØ¨Ø© Ø¨Ø¹Ø¯ Ø§Ù„ÙƒØ´Ù Ø§Ù„ÙƒØ§ÙÙŠ. Ù„Ù„ØªØ¨Ù„ÙŠØº Ø¹Ù† Ø³Ø¨Ø§Ù… Ù…Ù† Ù…Ø´ØªØ±Ùƒ Ø¢Ø®Ø± Ù…Ù† <span dir="LTR">ahbaab.com </span>ØŒ ØŒ ÙŠØ±Ø¬Ù‰ Ø§Ù„Ø§ØªØµØ§Ù„ Ø¨Ù†Ø§ Ø¨Ø§Ø³ØªØ®Ø¯Ø§Ù… ØµÙØ­Ø© Ø§ØªØµÙ„ Ø¨Ù†Ø§</p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	<span dir="LTR">6. </span>Ø§Ø³ØªØ¹Ø±Ø§Ø¶ ÙˆØªØºÙŠÙŠØ± Ø§Ù„Ù…Ù„Ù Ø§Ù„Ø´Ø®ØµÙŠ Ø§Ù„Ø®Ø§Øµ Ø¨Ùƒ</p>\r\n<p dir="RTL">\r\n	Ø¨Ø¹Ø¯ Ø§Ù„ØªØ³Ø¬ÙŠÙ„ ØŒ ÙŠÙ…ÙƒÙ†Ùƒ Ù…Ø±Ø§Ø¬Ø¹Ø© ÙˆØªØºÙŠÙŠØ± Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„ØªÙŠ Ù‚Ø¯Ù…Øª Ø£Ø«Ù†Ø§Ø¡ Ø§Ù„ØªØ³Ø¬ÙŠÙ„ Ø¹Ù† Ø·Ø±ÙŠÙ‚ Ø®Ø¯Ù…Ø© Ø§Ù„Ø£Ø¹Ø¶Ø§Ø¡ Ø§Ù„Ù‚Ø§Ø¦Ù…Ø© Ø¨Ù…Ø§ ÙÙŠ Ø°Ù„Ùƒ : ÙƒÙ„Ù…Ø© Ø§Ù„Ø³Ø± ÙˆØ¹Ù†ÙˆØ§Ù† Ø§Ù„Ø¨Ø±ÙŠØ¯ Ø§Ù„Ø¥Ù„ÙƒØªØ±ÙˆÙ†ÙŠ. Ø¥Ø°Ø§ Ù‚Ù…Øª Ø¨ØªØºÙŠÙŠØ± ÙƒÙ„Ù…Ø© Ø§Ù„Ø³Ø± ÙˆØ§Ù„Ø¨Ø±ÙŠØ¯ Ø§Ù„Ø¥Ù„ÙƒØªØ±ÙˆÙ†ÙŠ ÙˆÙ†Ø­Ù† ØªØªØ¨Ø¹ ÙƒÙ„Ù…Ø© Ø§Ù„Ù…Ø±ÙˆØ± Ø§Ù„Ù‚Ø¯ÙŠÙ…Ø© ÙˆØ§Ù„Ø¨Ø±ÙŠØ¯ Ø§Ù„Ø¥Ù„ÙƒØªØ±ÙˆÙ†ÙŠ. ÙŠÙ…ÙƒÙ†Ùƒ Ø£ÙŠØ¶Ø§ ØªØºÙŠÙŠØ± Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„ØªØ³Ø¬ÙŠÙ„ Ø§Ù„Ø®Ø§ØµØ© Ø¨Ùƒ Ù…Ø«Ù„ : Ø§Ù„Ø§Ø³Ù… ÙˆØ§Ù„Ø¹Ù†ÙˆØ§Ù† ÙˆØ§Ù„Ù…Ø¯ÙŠÙ†Ø© ÙˆØ§Ù„ÙˆÙ„Ø§ÙŠØ© ØŒ ÙˆØ§Ù„Ø±Ù…Ø² Ø§Ù„Ø¨Ø±ÙŠØ¯ÙŠ ØŒ Ø§Ù„Ø¨Ù„Ø¯ ØŒ Ø±Ù‚Ù… Ø§Ù„Ù‡Ø§ØªÙ ØŒ Ù„Ù…Ø­Ø© ØŒ Ù…Ø§Ø°Ø§ ÙŠØ­Ø¨ ÙˆÙ…Ø§Ø°Ø§ ÙŠÙƒØ±Ù‡ ØŒ ÙˆØ§Ù„Ù…Ø·Ù„ÙˆØ¨ Ù…Ù„Ù ØªØ§Ø±ÙŠØ® ÙˆØ§Ù„Ù…Ù‚Ø§Ù„Ø§Øª ÙˆÙŠØ­ÙØ¸ Ù…Ø¹Ø§ÙŠÙŠØ± Ø§Ù„Ø¨Ø­Ø«<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	Ø¨Ù†Ø§Ø¡ Ø¹Ù„Ù‰ Ø·Ù„Ø¨Ùƒ Ø§Ù„Ù…ÙƒØªÙˆØ¨ ØŒ Ø³Ù†Ù‚ÙˆÙ… Ø¨ØªØ¹Ù„ÙŠÙ‚ Ø¹Ø¶ÙˆÙŠØªÙƒÙ… ØŒ Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„Ø§ØªØµØ§Ù„ ØŒ ÙˆØ§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„Ù…Ø§Ù„ÙŠØ© Ù…Ù† Ù‚ÙˆØ§Ø¹Ø¯ Ø§Ù„Ø¨ÙŠØ§Ù†Ø§Øª Ø§Ù„Ù†Ø´Ø·Ø©. ÙˆØ³ÙŠØªÙ… ØªØ¹Ù„ÙŠÙ‚ Ù‡Ø°Ù‡ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª ÙÙŠ Ø£Ù‚Ø±Ø¨ ÙˆÙ‚Øª Ù…Ù…ÙƒÙ† Ø¨ØµÙˆØ±Ø© Ù…Ø¹Ù‚ÙˆÙ„Ø© ÙˆÙÙ‚Ø§ Ù„Ø³ÙŠØ§Ø³Ø© ØªØ¹Ù„ÙŠÙ‚ Ù„Ø¯ÙŠÙ†Ø§ ÙˆØ§Ù„Ù‚Ø§Ù†ÙˆÙ† Ø§Ù„ÙˆØ§Ø¬Ø¨ Ø§Ù„ØªØ·Ø¨ÙŠÙ‚. Ù„Ø¥Ø²Ø§Ù„Ø© Ø§Ù„ØªØ¹Ø±ÙŠÙ Ø§Ù„Ø®Ø§Øµ Ø¨Ùƒ Ø¨Ø­ÙŠØ« Ù„Ø§ ÙŠÙ…ÙƒÙ† Ù„Ù„Ø¢Ø®Ø±ÙŠÙ† Ù…Ø´Ø§Ù‡Ø¯ØªÙ‡ ØŒ ÙŠÙ…ÙƒÙ†Ùƒ Ø²ÙŠØ§Ø±Ø© ØµÙØ­Ø© Ù…Ù„Ù Ø¥Ù„ØºØ§Ø¡ ØªÙ†Ø´ÙŠØ· Ù…ØªÙˆÙØ±Ø© Ø¨Ø¹Ø¯ ØªØ³Ø¬ÙŠÙ„ Ø§Ù„Ø¯Ø®ÙˆÙ„<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	Ø³ÙˆÙ Ù†Ø­ØªÙØ¸ ÙÙŠ Ù…Ù„ÙØ§ØªÙ†Ø§ Ù„Ùƒ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„ØªÙŠ Ø·Ù„Ø¨ØªÙ‡Ø§ Ù„Ø¥Ø²Ø§Ù„Ø© Ù„Ø¸Ø±ÙˆÙ Ù…Ø¹ÙŠÙ†Ø© ØŒ Ù…Ø«Ù„ Ø­Ù„ Ø§Ù„Ù†Ø²Ø§Ø¹Ø§Øª ØŒ Ø§Ø³ØªÙƒØ´Ø§Ù Ø§Ù„Ù…Ø´Ø§ÙƒÙ„ ÙˆÙØ±Ø¶ Ø§Ù„Ø´Ø±ÙˆØ· ÙˆØ§Ù„Ø´Ø±ÙˆØ·. ÙƒØ°Ù„Ùƒ ØŒ ÙŠØªÙ… Ø£Ø¨Ø¯Ø§ Ù…Ø«Ù„ Ù‡Ø°Ù‡ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ù‚Ø¨Ù„ Ø¥Ø²Ø§Ù„ØªÙ‡Ø§ ØªÙ…Ø§Ù…Ø§ Ù…Ù† Ù‚ÙˆØ§Ø¹Ø¯ Ø¨ÙŠØ§Ù†Ø§ØªÙ†Ø§ Ø¨Ø³Ø¨Ø¨ Ø§Ù„Ù‚ÙŠÙˆØ¯ Ø§Ù„ØªÙ‚Ù†ÙŠØ© ÙˆØ§Ù„Ù‚Ø§Ù†ÙˆÙ†ÙŠØ© ØŒ Ø¨Ù…Ø§ ÙÙŠ Ø°Ù„Ùƒ Ø£Ù†Ø¸Ù…Ø© ØªØ®Ø²ÙŠÙ† &quot;Ø§Ø­ØªÙŠØ§Ø·ÙŠØ©&quot;.Ù„Ø°Ø§ ØŒ ÙŠØ¬Ø¨ Ø£Ù† Ù„Ø§ Ù†ØªÙˆÙ‚Ø¹ Ø£Ù† ØªÙƒÙˆÙ† Ø¬Ù…ÙŠØ¹ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„Ø´Ø®ØµÙŠØ© Ø§Ù„Ø®Ø§ØµØ© Ø¨Ùƒ Ù…Ø²Ø§Ù„Ø© ØªÙ…Ø§Ù…Ø§ Ù…Ù† Ù‚ÙˆØ§Ø¹Ø¯ Ø¨ÙŠØ§Ù†Ø§ØªÙ†Ø§ Ø§Ø³ØªØ¬Ø§Ø¨Ø© Ù„Ø·Ù„Ø¨Ø§ØªÙƒ<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	<span dir="LTR">7. </span>Ø§Ù„Ø³ÙŠØ·Ø±Ø© Ø¹Ù„Ù‰ ÙƒÙ„Ù…Ø© Ø§Ù„Ø³Ø±</p>\r\n<p dir="RTL">\r\n	Ø£Ù†Øª Ù…Ø³Ø¤ÙˆÙ„Ø§ Ø¹Ù† Ø¬Ù…ÙŠØ¹ Ø§Ù„Ø¥Ø¬Ø±Ø§Ø¡Ø§Øª Ø§Ù„ØªÙŠ Ø§ØªØ®Ø°Øª Ù…Ø¹ Ù…Ø¹Ù„ÙˆÙ…Ø§Øª ØªØ³Ø¬ÙŠÙ„ Ø§Ù„Ø¯Ø®ÙˆÙ„ ÙˆÙƒÙ„Ù…Ø© Ø§Ù„Ù…Ø±ÙˆØ± ØŒ Ø¨Ù…Ø§ ÙÙŠ Ø°Ù„Ùƒ Ø§Ù„Ø±Ø³ÙˆÙ….Ù„Ø°Ø§ ÙØ¥Ù†Ù†Ø§ Ù„Ø§ Ù†Ù†ØµØ­ Ø¨Ø§Ù„ÙƒØ´Ù Ø¹Ù† ÙƒÙ„Ù…Ø© Ù…Ø±ÙˆØ± <span dir="LTR">ahbaab.com </span>Ø£Ùˆ Ù…Ø¹Ù„ÙˆÙ…Ø§Øª ØªØ³Ø¬ÙŠÙ„ Ø§Ù„Ø¯Ø®ÙˆÙ„ Ø¥Ù„Ù‰ Ø£ÙŠ Ø·Ø±Ù Ø«Ø§Ù„Ø«. Ø¥Ø°Ø§ Ø§Ø®ØªØ±Øª Ù„ØªÙ‚Ø§Ø³Ù… Ù‡Ø°Ù‡ Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ù…Ø¹ Ø£Ø·Ø±Ø§Ù Ø«Ø§Ù„Ø«Ø© Ù„ØªÙˆÙØ± Ù„Ùƒ Ø®Ø¯Ù…Ø§Øª Ø¥Ø¶Ø§ÙÙŠØ© ØŒ ÙØ£Ù†Øª Ù…Ø³Ø¤ÙˆÙ„ Ø¹Ù† Ø¬Ù…ÙŠØ¹ Ø§Ù„Ø¥Ø¬Ø±Ø§Ø¡Ø§Øª Ø§Ù„ØªÙŠ Ø§ØªØ®Ø°Øª Ù…Ø¹ Ù…Ø¹Ù„ÙˆÙ…Ø§Øª ØªØ³Ø¬ÙŠÙ„ Ø§Ù„Ø¯Ø®ÙˆÙ„ ÙˆÙƒÙ„Ù…Ø© Ø§Ù„Ø³Ø± ØŒ ÙˆØ¨Ø§Ù„ØªØ§Ù„ÙŠ ÙŠØ¬Ø¨ Ù…Ø±Ø§Ø¬Ø¹Ø© Ø³ÙŠØ§Ø³Ø© ÙƒÙ„ Ø·Ø±Ù Ø«Ø§Ù„Ø« Ø§Ù„Ø®ØµÙˆØµÙŠØ©. Ø¥Ø°Ø§ ÙÙ‚Ø¯Øª Ø§Ù„Ø³ÙŠØ·Ø±Ø© Ø¹Ù„Ù‰ ÙƒÙ„Ù…Ø© Ø§Ù„Ø³Ø± Ø§Ù„Ø®Ø§ØµØ© Ø¨Ùƒ ØŒ Ù‚Ø¯ ØªÙÙ‚Ø¯ Ø³ÙŠØ·Ø±Ø© ÙƒØ¨ÙŠØ±Ø© Ø¹Ù„Ù‰ Ù…Ø¹Ù„ÙˆÙ…Ø§ØªÙƒ Ø§Ù„Ø´Ø®ØµÙŠØ© ÙˆÙŠÙ…ÙƒÙ† Ø£Ù† ØªØ®Ø¶Ø¹ Ù„Ø¥Ø¬Ø±Ø§Ø¡Ø§Øª Ù…Ù„Ø²Ù…Ø© Ù‚Ø§Ù†ÙˆÙ†Ø§ Ø§ØªØ®Ø°Øª Ù†ÙŠØ§Ø¨Ø© Ø¹Ù†Ùƒ.Ù„Ø°Ù„Ùƒ ØŒ Ø¥Ø°Ø§ ØªÙ… Ø§Ø®ØªØ±Ø§Ù‚ ÙƒÙ„Ù…Ø© Ø§Ù„Ù…Ø±ÙˆØ± Ø§Ù„Ø®Ø§ØµØ© Ø¨Ùƒ Ù„Ø£ÙŠ Ø³Ø¨Ø¨ Ù…Ù† Ø§Ù„Ø£Ø³Ø¨Ø§Ø¨ ØŒ ÙŠØ¬Ø¨ Ø¹Ù„Ù‰ Ø§Ù„ÙÙˆØ± ØªØºÙŠÙŠØ± Ø¨Ø§Ø³ÙˆØ±Ø¯ Ø§Ù„Ø®Ø§Øµ</p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	<span dir="LTR">8. </span>Ø¬Ø§Ù…Ø¹ÙŠ Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø£Ø®Ø±Ù‰</p>\r\n<p dir="RTL">\r\n	Ø¨Ø§Ø³ØªØ«Ù†Ø§Ø¡ Ù…Ø§ Ù‡Ùˆ Ø®Ù„Ø§Ù Ø°Ù„Ùƒ ÙÙŠ Ø³ÙŠØ§Ø³Ø© Ø§Ù„Ø®ØµÙˆØµÙŠØ© Ù‡Ø°Ù‡ ØŒ ÙØ¥Ù† Ù‡Ø°Ù‡ Ø§Ù„ÙˆØ«ÙŠÙ‚Ø© Ù„Ø§ ØªØªÙ†Ø§ÙˆÙ„ Ø³ÙˆÙ‰ Ø§Ø³ØªØ®Ø¯Ø§Ù… ÙˆØ§Ù„ÙƒØ´Ù Ø¹Ù† Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„ØªÙŠ Ù†Ø¬Ù…Ø¹Ù‡Ø§ Ù…Ù†Ùƒ. Ø¥Ù„Ù‰ Ø­Ø¯ Ø£Ù† ØªÙ‚ÙˆÙ… Ø¨Ø§Ù„Ø¥ÙØµØ§Ø­ Ø¹Ù† Ù…Ø¹Ù„ÙˆÙ…Ø§ØªÙƒ Ù„Ø£Ø·Ø±Ø§Ù Ø£Ø®Ø±Ù‰ ØŒ Ø³ÙˆØ§Ø¡ Ø£ÙƒØ§Ù†ÙˆØ§ Ø¹Ù„Ù‰ Ù…ÙˆØ§Ù‚Ø¹Ù†Ø§ Ø¹Ù„Ù‰ Ø§Ù„Ø¥Ù†ØªØ±Ù†Øª Ø£Ùˆ Ø¹Ù„Ù‰ Ù…ÙˆØ§Ù‚Ø¹ Ø£Ø®Ø±Ù‰ ÙÙŠ Ø¬Ù…ÙŠØ¹ Ø£Ù†Ø­Ø§Ø¡ Ø´Ø¨ÙƒØ© Ø§Ù„Ø¥Ù†ØªØ±Ù†Øª ØŒ Ù‚Ø¯ ØªØ·Ø¨Ù‚ Ù‚ÙˆØ§Ø¹Ø¯ Ù…Ø®ØªÙ„ÙØ© Ù„Ø§Ø³ØªØ®Ø¯Ø§Ù…Ù‡Ø§ Ø£Ùˆ Ø§Ù„ÙƒØ´Ù Ø¹Ù† Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„ØªÙŠ ØªÙƒØ´Ù Ù„Ù‡Ù…. Ø¥Ù„Ù‰ Ø­Ø¯ Ø£Ù† Ù†Ø³ØªØ®Ø¯Ù… Ø§Ù„Ù…Ø¹Ù„Ù†ÙŠÙ† Ø·Ø±Ù Ø«Ø§Ù„Ø« ØŒ ÙˆØ«Ø¨Ø§ØªÙ‡Ù… Ø¹Ù„Ù‰ Ø³ÙŠØ§Ø³Ø§Øª Ø§Ù„Ø®ØµÙˆØµÙŠØ© Ø§Ù„Ø®Ø§ØµØ© Ø¨Ù‡Ù….Ø¨Ù…Ø§ Ø£Ù† <span dir="LTR">ahbaab.com </span>Ù„Ø§ ØªØ³ÙŠØ·Ø± Ø¹Ù„Ù‰ Ø³ÙŠØ§Ø³Ø§Øª Ø§Ù„Ø®ØµÙˆØµÙŠØ© Ù„Ø£Ø·Ø±Ø§Ù Ø«Ø§Ù„Ø«Ø© ØŒ ÙØ¥Ù†Ùƒ ØªÙƒÙˆÙ† Ø®Ø§Ø¶Ø¹Ø§ Ù„Ø·Ø±Ø­ Ø§Ù„Ø£Ø³Ø¦Ù„Ø© Ù‚Ø¨Ù„ Ø§Ù„ÙƒØ´Ù Ø¹Ù† Ø§Ù„Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø§Ù„Ø´Ø®ØµÙŠØ© Ù„Ù„Ø¢Ø®Ø±ÙŠÙ†</p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	<span dir="LTR">9. </span>Ø£Ù…Ù†</p>\r\n<p dir="RTL">\r\n	<span dir="LTR">ahbaab.com </span>ÙŠØ³ØªØ®Ø¯Ù… Ø§Ù„Ù…Ù…Ø§Ø±Ø³Ø§Øª Ø§Ù„ØµÙ†Ø§Ø¹ÙŠØ© Ø§Ù„Ù‚ÙŠØ§Ø³ÙŠØ© Ù„Ù„Ø­ÙØ§Ø¸ Ø¹Ù„Ù‰ Ø³Ø±ÙŠØ© Ù…Ø¹Ù„ÙˆÙ…Ø§ØªÙƒ Ø§Ù„Ø´Ø®ØµÙŠØ© ØŒ Ø¨Ù…Ø§ ÙÙŠ Ø°Ù„Ùƒ &quot;Ø§Ù„Ø¬Ø¯Ø±Ø§Ù† Ø§Ù„Ù†Ø§Ø±ÙŠØ©&quot; ÙˆØ§Ù„Ù…Ù‚Ø§Ø¨Ø³ Ø§Ù„Ø¢Ù…Ù†Ø© Ø§Ù„Ø·Ø¨Ù‚Ø§Øª<span dir="LTR">. </span>&nbsp;<span dir="LTR">ahbaab.com </span>ÙŠØ¹Ø§Ù…Ù„ Ø§Ù„Ø¨ÙŠØ§Ù†Ø§Øª ÙƒØ£ØµÙ„ Ø§Ù„ØªÙŠ ÙŠØ¬Ø¨ Ø­Ù…Ø§ÙŠØªÙ‡Ø§ Ù…Ù† Ø§Ù„Ø¶ÙŠØ§Ø¹ ÙˆØ§Ù„Ø¯Ø®ÙˆÙ„ ØºÙŠØ± Ø§Ù„Ù…ØµØ±Ø­ Ø¨Ù‡.Ù†ÙˆØ¸Ù Ø§Ù„Ø¹Ø¯ÙŠØ¯ Ù…Ù† Ø§Ù„ØªÙ‚Ù†ÙŠØ§Øª Ø§Ù„Ø£Ù…Ù†ÙŠØ© Ø§Ù„Ù…Ø®ØªÙ„ÙØ© Ù„Ø­Ù…Ø§ÙŠØ© Ù‡Ø°Ù‡ Ø§Ù„Ø¨ÙŠØ§Ù†Ø§Øª Ù…Ù† Ø§Ù„ÙˆØµÙˆÙ„ ØºÙŠØ± Ø§Ù„Ù…ØµØ±Ø­ Ø¨Ù‡ Ù…Ù† Ù‚Ø¨Ù„ Ø£Ø¹Ø¶Ø§Ø¡ Ù…Ù† Ø¯Ø§Ø®Ù„ ÙˆØ®Ø§Ø±Ø¬ Ø§Ù„Ø´Ø±ÙƒØ©. ÙˆÙ…Ø¹ Ø°Ù„Ùƒ ØŒ &quot;Ø£Ù…Ù† ØªØ§Ù…&quot; Ù„Ø§ ÙˆØ¬ÙˆØ¯ Ù„Ù‡Ø§ Ø¹Ù„Ù‰ Ø´Ø¨ÙƒØ© Ø§Ù„Ø¥Ù†ØªØ±Ù†Øª<span dir="LTR">.</span></p>\r\n<p dir="RTL">\r\n	&nbsp;</p>\r\n<p dir="RTL">\r\n	<span dir="LTR">10. </span>Ø¥Ø´Ø¹Ø§Ø±</p>\r\n<p dir="RTL">\r\n	Ù‚Ø¯ Ù†Ù‚ÙˆÙ… Ø¨ØªØºÙŠÙŠØ± Ø³ÙŠØ§Ø³Ø© Ø§Ù„Ø®ØµÙˆØµÙŠØ© Ù‡Ø°Ù‡ Ù…Ù† ÙˆÙ‚Øª Ù„Ø¢Ø®Ø± Ø¨Ù†Ø§Ø¡ Ø¹Ù„Ù‰ ØªØ¹Ù„ÙŠÙ‚Ø§ØªÙƒÙ… ÙˆØ­Ø§Ø¬ØªÙ†Ø§ Ù„ØªØ¹ÙƒØ³ Ø¨Ø¯Ù‚Ø© ØªØ¬Ù…ÙŠØ¹Ù†Ø§ Ù„Ù„Ø¨ÙŠØ§Ù†Ø§Øª ÙˆÙ…Ù…Ø§Ø±Ø³Ø§Øª Ø§Ù„Ø¥ÙØµØ§Ø­. ÙƒÙ„ Ø§Ù„ØªØºÙŠÙŠØ±Ø§Øª Ø¹Ù„Ù‰ Ù‡Ø°Ù‡ Ø§Ù„Ø³ÙŠØ§Ø³Ø© ÙØ¹Ø§Ù„Ø© Ø¨Ø¹Ø¯ Ø¸Ù‡ÙˆØ±Ù‡Ø§ Ø¹Ù„Ù‰ Ø§Ù„Ù…ÙˆÙ‚Ø¹<span dir="LTR">.</span></p>\r\n');

-- --------------------------------------------------------

--
-- Table structure for table `scrolling`
--

CREATE TABLE IF NOT EXISTS `scrolling` (
  `scrolling_id` int(10) NOT NULL,
  `scrolling_desc` varchar(200) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `securitywarnings`
--

CREATE TABLE IF NOT EXISTS `securitywarnings` (
  `warning_en` varchar(10000) CHARACTER SET utf8 NOT NULL,
  `warning_ar` varchar(10000) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `securitywarnings`
--

INSERT INTO `securitywarnings` (`warning_en`, `warning_ar`) VALUES
('<p dir="ltr" style="">\r\n	Under Copyright.</p>\r\n', '<p align="right">\r\n	<span style="font-size:18px;"><strong>ØªØ­Ø°ÙŠØ±Ø§Øª Ø§Ù„Ø£Ù…Ø§Ù†</strong></span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ø§Ù† Ø§Ø¯Ø§Ø±Ø© Ù…ÙˆÙ‚Ø¹ <strong>Ø§Ø­Ø¨Ø§Ø¨ </strong>Ù‡ÙŠ Ø§Ø¯Ø§Ø±Ø© Ù…Ø³ØªÙ‚Ù„Ø© ÙˆÙ„Ø§ ÙŠØªØ¨Ø¹ Ù„Ù†Ø§ Ø§ÙŠ Ù…ÙˆÙ‚Ø¹ Ø§Ø®Ø± Ù„Ø§ Ù…Ù† Ù‚Ø±ÙŠØ¨ ÙˆÙ„Ø§ Ù…Ù† Ø¨Ø¹ÙŠØ¯ ÙƒÙ…Ø§ ÙˆØ§Ù†Ù‡ Ù„Ø¯Ø¨Ù†Ø§ ÙØ±ÙŠÙ‚ Ø¹Ù…Ù„ ÙŠØ¹Ù…Ù„ Ø¨Ø´ÙƒÙ„ Ù…ØªÙˆØ§ØµÙ„ Ù„Ù…Ø¯Ø© 24 Ø³Ø§Ø¹Ø© ÙŠÙˆÙ…ÙŠØ§</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ù„Ø°Ù„Ùƒ ØªØªÙˆØ¬Ù‡ Ø§Ø¯Ø§Ø±Ø© Ù…ÙˆÙ‚Ø¹ <strong>Ø§Ø­Ø¨Ø§Ø¨ </strong>Ø§Ù„Ù‰ Ù…Ø´Ø§Ø±ÙƒÙŠÙ†Ø§ Ø¨ØªØ­Ø°ÙŠØ±Ø§Øª Ø§Ù„Ø§Ù…Ø§Ù† ÙˆÙ†Ø§Ù…Ù„ Ù…Ù†ÙƒÙ… Ø§Ù„ØªÙ‚ÙŠØ¯ Ø¨Ù‡Ø§ </span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ø¹Ø¯Ù… Ø§Ø±Ø³Ø§Ù„ Ø§ÙŠ Ù…Ø¨Ù„Øº Ù…Ø§Ù„ÙŠ Ù„Ø§ÙŠ Ù…Ø´ØªØ±Ùƒ ØªØªØ¹Ø±ÙÙˆÙ† Ø¹Ù„ÙŠÙ‡ ÙÙŠ Ø§Ù„Ù…ÙˆÙ‚Ø¹ Ù…Ù‡Ù…Ø§ ÙƒØ§Ù†Øª Ø§Ù„Ø§Ø³Ø¨Ø§Ø¨ ÙˆØ§Ù„Ø¸Ø±ÙˆÙ</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ø¹Ø¯Ù… Ø§Ø¹Ø·Ø§Ø¡ Ø§ÙŠ Ø´Ø®Øµ ØªØªØ¹Ø±ÙÙˆÙ† Ø¹Ù„ÙŠÙ‡ ÙÙŠ Ø§Ù„Ù…ÙˆÙ‚Ø¹ Ø§ÙŠ Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø¹Ù† Ø­Ø³Ø§Ø¨Ø§ØªÙƒÙ… Ø§Ù„Ù…Ø§Ù„ÙŠØ© Ø§Ùˆ Ø§Ø±Ù‚Ø§Ù… Ø­Ø³Ø§Ø¨Ø§Øª Ø§Ùˆ Ø§ÙŠ Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø¹Ù† Ø¨Ø·Ø§Ù‚Ø§Øª Ø§Ù„Ø§Ø¦ØªÙ…Ø§Ù†</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ø¹Ø¯Ù… Ø§Ø¹Ø·Ø§Ø¡ Ø§ÙŠ Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø®Ø§ØµØ© Ù„Ø§ÙŠ Ù…Ø´ØªØ±Ùƒ ØªØªØ¹Ø±ÙÙˆÙ† Ø¹Ù„ÙŠÙ‡ ÙÙŠ Ø§Ù„Ù…ÙˆÙ‚Ø¹ Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø¹Ù† Ø­ÙŠØ§ØªÙƒÙ… Ø§Ù„Ø®Ø§ØµØ© Ø§Ùˆ Ø¹Ù…Ù„ÙƒÙ… Ø§Ùˆ Ø­Ø³Ø§Ø¨Ø§ØªÙƒÙ…</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ø¹Ø¯Ù… Ø§Ø¹Ø·Ø§Ø¡ Ø§ÙŠ Ù…Ø´ØªØ±Ùƒ ØªØªØ¹Ø±ÙÙˆÙ† Ø¹Ù„ÙŠÙ‡ ÙÙŠ Ø§Ù„Ù…ÙˆÙ‚Ø¹ Ø§ÙŠ Ù…Ø¹Ù„ÙˆÙ…Ø§Øª Ø¹Ù† Ø­Ø³Ø§Ø¨Ø§ØªÙƒÙ… ÙÙŠ Ø§Ù„Ù…ÙˆÙ‚Ø¹ Ø§Ùˆ Ø§ÙŠ Ù…ÙˆÙ‚Ø¹ Ø§Ø®Ø± Ø§Ùˆ Ø§Ø¹Ø·Ø§Ø¡ Ø§ÙŠ Ø§Ø³Ù… Ù…Ø³ØªØ®Ø¯Ù… Ø§ÙˆÙƒÙ„Ù…Ø© Ø§Ù„Ø³Ø± Ù„Ø§ÙŠ ÙƒØ§Ù†</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ø¨ØªÙ… Ø§ÙŠÙ‚Ø§Ù Ø§Ù„Ù…Ø´ØªØ±Ùƒ Ø¨Ø¯ÙˆÙ† Ø³Ø§Ø¨Ù‚ Ø§Ù†Ø°Ø§Ø± ÙÙ‰ Ø­Ø§Ù„Ø© ÙƒØªØ§Ø¨Ø© Ø§Ù„Ø§Ø³Ù… Ø§Ù„Ø¸Ø§Ù‡Ø± Ø¹Ù„Ù‰ Ø§Ù„Ù…ÙˆÙ‚Ø¹ Ø¨Ø´ÙƒÙ„ ØºÙŠØ± Ù„Ø§Ø¦Ù‚ Ø§Ùˆ ÙŠØ­ØªÙˆÙ‰ Ø¹Ù„Ù‰ ÙˆØ³ÙŠÙ„Ø© Ø§ØªØµØ§Ù„ Ø§Ùˆ ÙƒÙ„Ù…Ø© Ø®Ø§Ø±Ø¬Ø© Ø§Ùˆ Ù…Ø¹Ù†Ù‰ ØºÙŠØ± Ø§Ù„Ø§Ø³Ù…Ø§Ø¡ Ø§Ù„Ù…ØªØ¹Ø§Ø±Ù Ø¹Ù„ÙŠÙ‡Ø§</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ø§Ù„Ù…ÙˆÙ‚Ø¹ ØºÙŠØ± Ù…Ø³Ø¤Ù„ Ø¹Ù† Ø§Ù‰ Ù†ØªØ§Ø¦Ø¬ Ø³Ù„Ø¨ÙŠÙ‡ Ù„ÙˆØ¶Ø¹ ØµÙˆØ± Ø§Ù„Ø¨Ù†Ø§Øª Ø§Ù„Ø±Ø§ØºØ¨Ø§Øª ÙÙ‰ Ø§Ù„Ø²ÙˆØ§Ø¬ Ù…Ù† Ø®Ù„Ø§Ù„ Ø§Ù„Ù…ÙˆÙ‚Ø¹</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">Ø§Ù„Ù…ÙˆÙ‚Ø¹ ØºÙŠØ± Ù…Ø³Ø¤Ù„ Ø¹Ù† Ø§Ù‰ Ù†ØªØ§Ø¦Ø¬ Ø³Ù„Ø¨ÙŠÙ‡ Ù„Ø§Ù‰ ØªØ¹Ø§Ø±Ù Ø®Ø§Ø±Ø¬ Ø§Ù„Ù…ÙˆÙ‚Ø¹ Ù…Ù† Ø®Ù„Ø§Ù„ Ø§Ù„Ø¨Ø±ÙŠØ¯ Ø§Ùˆ Ø§Ù„ØªÙ„ÙŠÙÙˆÙ†</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">ÙŠØ­Ù‚ Ù„Ù…ÙˆÙ‚Ø¹&nbsp;Ø§Ø­Ø¨Ø§Ø¨ Ø§ÙŠÙ‚Ø§Ù Ø§Ù‰ Ø¹Ø¶Ùˆ ÙŠØªØ¹Ø¯Ù‰ Ø¹Ù„Ù‰ Ø§Ù„Ù…ÙˆÙ‚Ø¹ Ø¨Ø§Ù‰ Ø´ÙƒÙ„ Ù…Ù† Ø§Ù„Ø§Ø´ÙƒØ§Ù„ Ø³ÙˆØ§Ø¡ ÙƒØªØ§Ø¨ÙŠØ§ Ø§Ùˆ Ù„ÙØ¸ÙŠØ§</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">ÙŠØ­Ù‚ Ù„Ø§Ø¯Ø§Ø±Ø© Ù…ÙˆÙ‚Ø¹ Ø§Ø­Ø¨Ø§Ø¨ ØªØºÙŠÙŠØ± Ø§Ùˆ ØªØ¨Ø¯ÙŠÙ„ Ø´Ø±ÙˆØ· Ø§Ù„Ø§Ø³ØªØ®Ø¯Ø§Ù… Ø§Ùˆ ØªØ­Ø°ÙŠØ±Ø§Øª Ø§Ù„Ø§Ù…Ø§Ù† ÙÙŠ Ø§ÙŠ ÙˆÙ‚Øª ØªØ±Ø§Ù‡ Ø§Ù„Ø§Ø¯Ø§Ø±Ø© Ù…Ù†Ø§Ø³Ø¨</span></p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	&nbsp;</p>\r\n<p align="right">\r\n	<span dir="RTL">ÙŠÙ…ÙƒÙ†ÙƒÙ… Ø¯Ø§Ø¦Ù…Ø§ Ù…Ø±Ø§Ø³Ù„Ø© Ø§Ø¯Ø§Ø±Ø© Ø§Ù„Ù…ÙˆÙ‚Ø¹ ÙˆØ¹Ù„Ù‰ Ù…Ø¯Ø§Ø± Ø§Ù„Ø³Ø§Ø¹Ø© Ø¹Ø¨Ø± </span></p>\r\n<p align="right">\r\n	<a href="mailto:info@ahbab.net">info@ahbaab.net</a></p>\r\n');

-- --------------------------------------------------------

--
-- Table structure for table `tempmass`
--

CREATE TABLE IF NOT EXISTS `tempmass` (
  `to_account` int(7) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `timezones`
--

CREATE TABLE IF NOT EXISTS `timezones` (
  `timezone_id` int(3) NOT NULL,
  `timezone_desc_en` varchar(200) CHARACTER SET utf8 NOT NULL,
  `timezone_desc_ar` varchar(200) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `timezones`
--

INSERT INTO `timezones` (`timezone_id`, `timezone_desc_en`, `timezone_desc_ar`) VALUES
(2, 'Mecca', 'Ù…ÙƒØ©');

-- --------------------------------------------------------

--
-- Table structure for table `transactions`
--

CREATE TABLE IF NOT EXISTS `transactions` (
  `transaction_id` int(20) NOT NULL,
  `amount` double NOT NULL,
  `currency` varchar(5) CHARACTER SET utf8 NOT NULL,
  `card_company_id` int(3) NOT NULL,
  `transaction_date` date NOT NULL,
  `account_id` int(10) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `usage_purpose`
--

CREATE TABLE IF NOT EXISTS `usage_purpose` (
  `purpose_id` int(4) NOT NULL,
  `purpose_desc_en` varchar(200) CHARACTER SET utf8 NOT NULL,
  `purpose_desc_ar` varchar(200) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `usage_purpose`
--

INSERT INTO `usage_purpose` (`purpose_id`, `purpose_desc_en`, `purpose_desc_ar`) VALUES
(1, 'Normal Marriage', 'Ø²ÙˆØ§Ø¬ Ø¹Ø§Ø¯ÙŠ'),
(3, 'mysiar marriage', 'Ø²ÙˆØ§Ø¬ Ù…Ø³ÙŠØ§Ø±'),
(4, 'new contacts', 'ØªÙˆØ§ØµÙ„ ÙˆØªØ¹Ø§Ø±Ù'),
(5, 'internet friends', 'Ø§ØµØ¯Ù‚Ø§Ø¡ Ø¹Ø¨Ø± Ø§Ù„Ù†Øª'),
(6, 'share stories', 'ØªØ¨Ø§Ø¯Ù„ Ø§ÙÙƒØ§Ø± ÙˆØ§Ø­Ø§Ø¯ÙŠØ«'),
(7, 'Meet new people', 'ØªØ¹Ø§Ø±Ù Ø¹Ù„Ù‰ Ø§Ù†Ø§Ø³ Ø¬Ø¯Ø¯'),
(8, 'Meet new culture', 'ØªØ¹Ø§Ø±Ù Ø¹Ù„Ù‰ Ø«Ù‚Ø§ÙØ§Øª Ø¬Ø¯ÙŠØ¯Ø©'),
(9, 'After discusion', 'Ø¨Ø¹Ø¯ Ø§Ù„ØªÙØ§Ù‡Ù…'),
(10, 'Bigami', 'Ø²ÙˆØ§Ø¬ ØªØ¹Ø¯Ø¯'),
(11, 'Other', 'ØºÙŠØ± Ø°Ù„Ùƒ');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `user_id` int(2) NOT NULL,
  `username` varchar(100) CHARACTER SET utf8 NOT NULL,
  `pass` varchar(100) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `username`, `pass`) VALUES
(1, 'kwebadmin', 'kweb@dm1n');

-- --------------------------------------------------------

--
-- Table structure for table `user_colors`
--

CREATE TABLE IF NOT EXISTS `user_colors` (
  `user_id` int(10) NOT NULL,
  `user_color` varchar(200) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `visits`
--

CREATE TABLE IF NOT EXISTS `visits` (
  `visit_from` int(7) NOT NULL,
  `visit_to` int(7) NOT NULL,
  `visit_date` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `weights`
--

CREATE TABLE IF NOT EXISTS `weights` (
  `weight_id` int(3) NOT NULL,
  `weight_desc_en` varchar(100) CHARACTER SET utf8 NOT NULL,
  `weight_desc_ar` varchar(100) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `weights`
--

INSERT INTO `weights` (`weight_id`, `weight_desc_en`, `weight_desc_ar`) VALUES
(1, 'Thin1', 'Ø¶Ø¹ÙŠÙ'),
(3, 'Fat', 'Ø³Ù…ÙŠÙ†'),
(4, 'Normal', 'Ø¹Ø§Ø¯ÙŠ'),
(5, 'Sporty', 'Ø±ÙŠØ§Ø¶ÙŠ'),
(6, 'Robust', 'ØµÙ„Ø¨');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `accounts`
--
ALTER TABLE `accounts`
  ADD PRIMARY KEY (`account_id`);

--
-- Indexes for table `ages`
--
ALTER TABLE `ages`
  ADD PRIMARY KEY (`age_id`);

--
-- Indexes for table `available_time`
--
ALTER TABLE `available_time`
  ADD PRIMARY KEY (`time_frame_id`);

--
-- Indexes for table `bulkmessages`
--
ALTER TABLE `bulkmessages`
  ADD PRIMARY KEY (`message_id`);

--
-- Indexes for table `card_companies`
--
ALTER TABLE `card_companies`
  ADD PRIMARY KEY (`company_id`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`category_id`);

--
-- Indexes for table `contact_preferences`
--
ALTER TABLE `contact_preferences`
  ADD PRIMARY KEY (`account_id`,`way_id`);

--
-- Indexes for table `contact_ways`
--
ALTER TABLE `contact_ways`
  ADD PRIMARY KEY (`way_id`);

--
-- Indexes for table `countries`
--
ALTER TABLE `countries`
  ADD PRIMARY KEY (`country_id`);

--
-- Indexes for table `educ_levels`
--
ALTER TABLE `educ_levels`
  ADD PRIMARY KEY (`educ_level_id`);

--
-- Indexes for table `emails`
--
ALTER TABLE `emails`
  ADD PRIMARY KEY (`mail_id`);

--
-- Indexes for table `eye_colors`
--
ALTER TABLE `eye_colors`
  ADD PRIMARY KEY (`color_id`);

--
-- Indexes for table `hair_color`
--
ALTER TABLE `hair_color`
  ADD PRIMARY KEY (`color_id`);

--
-- Indexes for table `heights`
--
ALTER TABLE `heights`
  ADD PRIMARY KEY (`height_id`);

--
-- Indexes for table `images`
--
ALTER TABLE `images`
  ADD PRIMARY KEY (`image_id`);

--
-- Indexes for table `jobs`
--
ALTER TABLE `jobs`
  ADD PRIMARY KEY (`job_id`);

--
-- Indexes for table `lastactivity`
--
ALTER TABLE `lastactivity`
  ADD PRIMARY KEY (`account_id`);

--
-- Indexes for table `marital_status`
--
ALTER TABLE `marital_status`
  ADD PRIMARY KEY (`status_id`);

--
-- Indexes for table `mass_message`
--
ALTER TABLE `mass_message`
  ADD PRIMARY KEY (`message_id`);

--
-- Indexes for table `messages`
--
ALTER TABLE `messages`
  ADD PRIMARY KEY (`message_id`);

--
-- Indexes for table `pendingmail`
--
ALTER TABLE `pendingmail`
  ADD PRIMARY KEY (`mail_id`);

--
-- Indexes for table `scrolling`
--
ALTER TABLE `scrolling`
  ADD PRIMARY KEY (`scrolling_id`);

--
-- Indexes for table `timezones`
--
ALTER TABLE `timezones`
  ADD PRIMARY KEY (`timezone_id`);

--
-- Indexes for table `transactions`
--
ALTER TABLE `transactions`
  ADD PRIMARY KEY (`transaction_id`);

--
-- Indexes for table `usage_purpose`
--
ALTER TABLE `usage_purpose`
  ADD PRIMARY KEY (`purpose_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`);

--
-- Indexes for table `user_colors`
--
ALTER TABLE `user_colors`
  ADD PRIMARY KEY (`user_id`);

--
-- Indexes for table `weights`
--
ALTER TABLE `weights`
  ADD PRIMARY KEY (`weight_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `accounts`
--
ALTER TABLE `accounts`
  MODIFY `account_id` int(10) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=52;
--
-- AUTO_INCREMENT for table `ages`
--
ALTER TABLE `ages`
  MODIFY `age_id` int(3) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=13;
--
-- AUTO_INCREMENT for table `available_time`
--
ALTER TABLE `available_time`
  MODIFY `time_frame_id` int(10) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT for table `bulkmessages`
--
ALTER TABLE `bulkmessages`
  MODIFY `message_id` int(10) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `card_companies`
--
ALTER TABLE `card_companies`
  MODIFY `company_id` int(2) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `category_id` int(10) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `contact_ways`
--
ALTER TABLE `contact_ways`
  MODIFY `way_id` int(3) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT for table `countries`
--
ALTER TABLE `countries`
  MODIFY `country_id` int(6) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=27;
--
-- AUTO_INCREMENT for table `educ_levels`
--
ALTER TABLE `educ_levels`
  MODIFY `educ_level_id` int(5) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `emails`
--
ALTER TABLE `emails`
  MODIFY `mail_id` int(10) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `eye_colors`
--
ALTER TABLE `eye_colors`
  MODIFY `color_id` int(3) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT for table `hair_color`
--
ALTER TABLE `hair_color`
  MODIFY `color_id` int(3) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT for table `heights`
--
ALTER TABLE `heights`
  MODIFY `height_id` int(3) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `images`
--
ALTER TABLE `images`
  MODIFY `image_id` int(10) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=116;
--
-- AUTO_INCREMENT for table `jobs`
--
ALTER TABLE `jobs`
  MODIFY `job_id` int(6) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=17;
--
-- AUTO_INCREMENT for table `marital_status`
--
ALTER TABLE `marital_status`
  MODIFY `status_id` int(3) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `mass_message`
--
ALTER TABLE `mass_message`
  MODIFY `message_id` int(10) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT for table `messages`
--
ALTER TABLE `messages`
  MODIFY `message_id` int(20) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=72;
--
-- AUTO_INCREMENT for table `pendingmail`
--
ALTER TABLE `pendingmail`
  MODIFY `mail_id` int(10) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `scrolling`
--
ALTER TABLE `scrolling`
  MODIFY `scrolling_id` int(10) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `timezones`
--
ALTER TABLE `timezones`
  MODIFY `timezone_id` int(3) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `transactions`
--
ALTER TABLE `transactions`
  MODIFY `transaction_id` int(20) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `usage_purpose`
--
ALTER TABLE `usage_purpose`
  MODIFY `purpose_id` int(4) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(2) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `user_colors`
--
ALTER TABLE `user_colors`
  MODIFY `user_id` int(10) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT for table `weights`
--
ALTER TABLE `weights`
  MODIFY `weight_id` int(3) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
