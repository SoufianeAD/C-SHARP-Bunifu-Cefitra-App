CREATE DATABASE ProjetTutore;
USE ProjetTutore;

CREATE TABLE Client(
    codeClient VARCHAR(50),
    nomClient VARCHAR(50),
    telClient VARCHAR(50),
    addresseClient VARCHAR(50),
    dateInscriptionClient DATE,
    PRIMARY KEY (codeClient)
);

CREATE TABLE Fournisseur(
    codeFournisseur VARCHAR(50),
    nomFournisseur VARCHAR(50),
    telFournisseur VARCHAR(50),
    addresseFournisseur VARCHAR(50),
    dateInscriptionFournisseur DATE,
    PRIMARY KEY (codeFournisseur)
);

CREATE TABLE OperationClient(
    codeOperationClient VARCHAR(50),
    codeClientOperationClient VARCHAR(50),
    modePaiementOperationClient VARCHAR(50),
    montantOperationClient FLOAT,
    reglerOperationClient FLOAT,
    resteOperationClient FLOAT,
    designationOperationClient VARCHAR(50),
    quantiteOperationClient FLOAT,
    prixUnitaireOperationClient FLOAT,
    dateOperationClient DATE,
    PRIMARY KEY (codeOperationClient),
    FOREIGN KEY (codeClientOperationClient) REFERENCES Client(codeClient)
);

CREATE TABLE OperationFournisseur(
    codeOperationFournisseur VARCHAR(50),
    codeFournisseurOperationFournisseur VARCHAR(50),
    modePaiementOperationFournisseur VARCHAR(50),
    montantOperationFournisseur FLOAT,
    reglerOperationFournisseur FLOAT,
    resteOperationFournisseur FLOAT,
    designationOperationFournisseur VARCHAR(50),
    quantiteOperationFournisseur FLOAT,
    prixUnitaireOperationFournisseur FLOAT,
    dateOperationFournisseur DATE,
    PRIMARY KEY (codeOperationFournisseur),
    FOREIGN KEY (codeFournisseurOperationFournisseur) REFERENCES Fournisseur(codeFournisseur)
);