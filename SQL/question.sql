CREATE TABLE `question` (
  `question_id` int NOT NULL,
  `quiz_id` int NOT NULL,
  `question_text` varchar(45) NOT NULL,
  `answer_1` varchar(45) NOT NULL,
  `answer_2` varchar(45) NOT NULL,
  `answer_3` varchar(45) NOT NULL,
  `answer_4` varchar(45) NOT NULL,
  `correct` int NOT NULL,
  PRIMARY KEY (`question_id`),
  KEY `question_fk1_idx` (`quiz_id`),
  CONSTRAINT `question_fk1` FOREIGN KEY (`quiz_id`) REFERENCES `quiz` (`quiz_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
