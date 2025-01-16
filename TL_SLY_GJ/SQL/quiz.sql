CREATE TABLE `quiz` (
  `quiz_id` int NOT NULL,
  `user_id` int NOT NULL,
  `subject_id` int NOT NULL,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`quiz_id`),
  KEY `quiz_fk2_idx` (`subject_id`),
  KEY `quiz_fk1_idx` (`user_id`),
  CONSTRAINT `quiz_fk1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`),
  CONSTRAINT `quiz_fk2` FOREIGN KEY (`subject_id`) REFERENCES `subject` (`subject_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
