DROP TABLE IF EXISTS attachement_projet;
DROP TABLE IF EXISTS projet;
DROP TABLE IF EXISTS attachement_photo;
DROP TABLE IF EXISTS attachement_localisation;
DROP TABLE IF EXISTS attachement_instance;
DROP TABLE IF EXISTS attachement;

CREATE TABLE attachement
(
    id_attachement SERIAL,
    numero_attachement VARCHAR(50) NOT NULL,
    numero_serie VARCHAR(50) NOT NULL,
    type_compatibilite VARCHAR(50) NOT NULL,
    marque VARCHAR(50) NOT NULL,
    modele VARCHAR(50) NOT NULL,
    hauteur_en_metre DECIMAL NOT NULL,
    largeur_en_metre DECIMAL NOT NULL,
    nb_heure_entre_entretient DECIMAL NOT NULL,
    CONSTRAINT attachement_pk PRIMARY KEY (id_attachement),
    CONSTRAINT numero_attachement_unique UNIQUE (numero_attachement),
    CONSTRAINT numero_serie_unique UNIQUE (numero_serie)
);

CREATE TABLE attachement_instance
(
    id_attachement_instance SERIAL,
    id_attachement INTEGER NOT NULL,
    etat_general VARCHAR(1000) NOT NULL,
    type_compatibilite VARCHAR(50) NOT NULL,
    nb_heure_entre_entretient DECIMAL NOT NULL,
    CONSTRAINT attachement_instance_pk PRIMARY KEY (id_attachement_instance),
    CONSTRAINT attachement_instance_id_attachement_fk FOREIGN KEY (id_attachement) REFERENCES attachement(id_attachement)
);

CREATE TABLE attachement_localisation
(
    id_attachement_localisation SERIAL,
    id_attachement INTEGER NOT NULL,
    description VARCHAR(250) NOT NULL,
    remarque VARCHAR(250) NULL,
    gamme_produit VARCHAR(250) NULL,
    classe VARCHAR(250) NULL,
    classement VARCHAR(250) NULL,
    division VARCHAR(250) NULL,
    industrie VARCHAR(250) NULL,
    produit VARCHAR(250) NULL,
    CONSTRAINT attachement_localisation_pk PRIMARY KEY (id_attachement_localisation),
    CONSTRAINT attachement_localisation_id_attachement_fk FOREIGN KEY (id_attachement) REFERENCES attachement(id_attachement)
);

CREATE TABLE attachement_photo
(
    id_attachement_photo SERIAL,
    id_attachement INTEGER NOT NULL,
    image_url VARCHAR(250) NOT NULL,
    CONSTRAINT attachement_photo_pk PRIMARY KEY (id_attachement_photo),
    CONSTRAINT attachement_photo_id_attachement_fk FOREIGN KEY (id_attachement) REFERENCES attachement(id_attachement)
);

CREATE TABLE projet
(
    id_projet SERIAL,
    nom VARCHAR(250) NOT NULL,
    CONSTRAINT projet_pk PRIMARY KEY (id_projet)
);

CREATE TABLE attachement_projet
(
    id_attachement_projet SERIAL,
    id_projet INTEGER NOT NULL,
    id_attachement_instance INTEGER NOT NULL,
    CONSTRAINT attachement_projet_pk PRIMARY KEY (id_attachement_projet),
    CONSTRAINT attachement_projet_id_projet_fk FOREIGN KEY (id_projet) REFERENCES projet(id_projet),
    CONSTRAINT attachement_projet_id_attachement_instance_fk FOREIGN KEY (id_attachement_instance) REFERENCES attachement_instance(id_attachement_instance)
);
