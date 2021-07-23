CREATE TABLE lists(  
    id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
    name varchar(255) comment 'List Name',
    creatorId VARCHAR(255) NOT NULL COMMENT 'FK: User Account',
    FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 comment '';
CREATE TABLE tasks(  
    id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
    name varchar(255) comment 'Task Name',
    isDone TINYINT DEFAULT 0 COMMENT 'Is task done',
    creatorId VARCHAR(255) NOT NULL COMMENT 'FK: User Account',
    listId INT NOT NULL COMMENT 'FK: List',
    FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
    FOREIGN KEY (listId) REFERENCES lists(id) ON DELETE CASCADE
) default charset utf8 comment '';