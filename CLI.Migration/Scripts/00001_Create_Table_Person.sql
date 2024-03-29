CREATE TABLE "User"
(
    Id        bigint PRIMARY KEY,
    Name      varchar(255) NOT NULL,
    Role      varchar(100) NOT NULL,
    Email     varchar(255),
    BirthDate date,
    CreatedAt timestamp    NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CreatedBy bigint       NOT NULL,
    UpdatedAt timestamp    NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedBy bigint       NOT NULL,
    IsDeleted boolean      NOT NULL
);
