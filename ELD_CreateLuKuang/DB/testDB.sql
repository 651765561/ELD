/*
Navicat MySQL Data Transfer

Source Server         : 192.168.0.170
Source Server Version : 50556
Source Host           : 192.168.0.170:3306
Source Database       : test

Target Server Type    : MYSQL
Target Server Version : 50556
File Encoding         : 936

Date: 2017-12-26 13:01:03
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `scheduler`
-- ----------------------------
DROP TABLE IF EXISTS `scheduler`;
CREATE TABLE `scheduler` (
  `id` int(4) NOT NULL AUTO_INCREMENT COMMENT '??',
  `groupName` varchar(50) DEFAULT '' COMMENT '????????',
  `jobName` varchar(50) DEFAULT '' COMMENT '????????',
  `trigggerName` varchar(50) DEFAULT '' COMMENT '?????',
  `state` int(4) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of scheduler
-- ----------------------------
INSERT INTO `scheduler` VALUES ('1', 'group1', 'job1', 'trigger1', '0');
INSERT INTO `scheduler` VALUES ('3', 'group3', 'job3', 'trigger3', '0');
INSERT INTO `scheduler` VALUES ('6', 'group2', 'job2', 'trigger2', '0');

-- ----------------------------
-- Table structure for `serverip`
-- ----------------------------
DROP TABLE IF EXISTS `serverip`;
CREATE TABLE `serverip` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `rtsp` varchar(200) DEFAULT NULL,
  `path` varchar(200) DEFAULT NULL,
  `qidong` bit(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of serverip
-- ----------------------------
INSERT INTO `serverip` VALUES ('5', 'rtsp://admin:admin0123456@192.168.0.38', ':9001/ccc', '');
INSERT INTO `serverip` VALUES ('3', 'rtsp://admin:admin0123456@192.168.0.58', ':9002/ccc', '');
