DROP TABLE IF EXISTS attachement_projet;
DROP TABLE IF EXISTS attachement_photo;
DROP TABLE IF EXISTS attachement_localisation;
DROP TABLE IF EXISTS attachement_instance;
DROP TABLE IF EXISTS attachement;
DROP TABLE IF EXISTS machine_projet;
DROP TABLE IF EXISTS machine_instance_photo;
DROP TABLE IF EXISTS machine_instance;
DROP TABLE IF EXISTS machine_localisation;
DROP TABLE IF EXISTS machine_photo;
DROP TABLE IF EXISTS machine;
DROP TABLE IF EXISTS projet_photo;
DROP TABLE IF EXISTS projet_membre;
DROP TABLE IF EXISTS projet;
DROP TABLE IF EXISTS membre;
DROP TABLE IF EXISTS client;
DROP TABLE IF EXISTS utilisateur;
DROP TABLE IF EXISTS role;
DROP TABLE IF EXISTS permission;
DROP TABLE IF EXISTS role_permission;

CREATE TABLE client
(
  id_client SERIAL,
  adresse_principale VARCHAR(250) NOT NULL,
  adresse_secondaire VARCHAR(250) NULL,
  telephone VARCHAR(10) NOT NULL,
  nom_contact VARCHAR(100) NOT NULL,
  courriel VARCHAR(50) NOT NULL,
  site_web VARCHAR(250) NULL,
  CONSTRAINT client_pk PRIMARY KEY (id_client)
);

CREATE TABLE membre
(
  id_membre SERIAL,
  nom_complet VARCHAR(100) NOT NULL,
  telephone VARCHAR(10) NOT NULL,
  CONSTRAINT membre_pk PRIMARY KEY (id_membre)
);

CREATE TABLE projet
(
    id_projet SERIAL,
    nom VARCHAR(250) NOT NULL,
    CONSTRAINT projet_pk PRIMARY KEY (id_projet)
);

CREATE TABLE projet_membre
(
  id_projet_membre SERIAL,
  id_projet INTEGER NOT NULL,
  id_membre INTEGER NOT NULL,
  CONSTRAINT projet_membre_pk PRIMARY KEY (id_projet_membre),
  CONSTRAINT projet_membre_id_projet_fk FOREIGN KEY (id_projet) REFERENCES projet(id_projet) ON DELETE CASCADE,
  CONSTRAINT projet_membre_id_membre_fk FOREIGN KEY (id_membre) REFERENCES membre(id_membre) ON DELETE CASCADE
);

CREATE TABLE projet_photo
(
  id_projet_photo SERIAL,
  id_projet INTEGER NOT NULL,
  image_url VARCHAR(250) NOT NULL,
  CONSTRAINT projet_photo_pk PRIMARY KEY (id_projet_photo) ON DELETE CASCADE,
  CONSTRAINT projet_photo_id_projet_fk FOREIGN KEY (id_projet) REFERENCES projet(id_projet) ON DELETE CASCADE
);

CREATE TABLE machine
(
  id_machine SERIAL,
  marque VARCHAR(50) NOT NULL,
  modele VARCHAR(50) NOT NULL,
  hauteur DECIMAL NOT NULL,
  largeur DECIMAL NOT NULL,
  poids DECIMAL NOT NULL,
  capacite DECIMAL NOT NULL,
  nb_heure_entre_entretient DECIMAL NOT NULL,
  type_compatibilite VARCHAR(50) NOT NULL,
  CONSTRAINT machine_pk PRIMARY KEY (id_machine)
);

CREATE TABLE machine_instance
(
  id_machine_instance SERIAL,
  id_machine INTEGER NOT NULL,
  nb_heure_utilisation DECIMAL NOT NULL,
  numero_serie VARCHAR(50) NOT NULL,
  description VARCHAR(250) NULL,
  CONSTRAINT machine_instance_pk PRIMARY KEY (id_machine_instance),
  CONSTRAINT machine_instance_id_machine_fk FOREIGN KEY (id_machine) REFERENCES machine(id_machine) ON DELETE CASCADE
);

CREATE TABLE machine_projet
(
  id_machine_projet SERIAL,
  id_projet INTEGER NOT NULL,
  id_machine_instance INTEGER NOT NULL,
  CONSTRAINT machine_projet_pk PRIMARY KEY (id_machine_projet),
  CONSTRAINT machine_projet_id_projet_fk FOREIGN KEY (id_projet) REFERENCES projet(id_projet) ON DELETE CASCADE,
  CONSTRAINT machine_projet_id_machine_instance_fk FOREIGN KEY (id_machine_instance) REFERENCES machine_instance(id_machine_instance) ON DELETE CASCADE
);

CREATE TABLE machine_photo
(
  id_machine_photo SERIAL,
  id_machine INTEGER NOT NULL,
  image_url VARCHAR(250) NOT NULL,
  CONSTRAINT machine_photo_pk PRIMARY KEY (id_machine_photo),
  CONSTRAINT machine_photo_id_machine_fk FOREIGN KEY (id_machine) REFERENCES machine(id_machine) ON DELETE CASCADE
);

CREATE TABLE machine_localisation
(
  id_machine_localisation SERIAL,
  id_machine INTEGER NOT NULL,
  description VARCHAR(250) NULL,
  remarque VARCHAR(250) NULL,
  CONSTRAINT machine_localisation_pk PRIMARY KEY (id_machine_localisation),
  CONSTRAINT machine_localisation_id_machine_fk FOREIGN KEY (id_machine) REFERENCES machine(id_machine) ON DELETE CASCADE
);

CREATE TABLE machine_instance_photo
(
  id_machine_instance_photo SERIAL,
  id_machine_instance INTEGER NOT NULL,
  image_url VARCHAR(250) NOT NULL,
  CONSTRAINT machine_instance_photo_pk PRIMARY KEY (id_machine_instance_photo),
  CONSTRAINT machine_instance_photo_id_machine_instance_fk FOREIGN KEY (id_machine_instance) REFERENCES machine_instance(id_machine_instance) ON DELETE CASCADE
);

CREATE TABLE attachement
(
    id_attachement SERIAL,
    numero_attachement VARCHAR(50) NOT NULL,
    numero_serie VARCHAR(50) NOT NULL,
    type_compatibilite VARCHAR(50) NOT NULL,
    marque VARCHAR(50) NOT NULL,
    modele VARCHAR(50) NOT NULL,
    hauteur DECIMAL NOT NULL,
    largeur DECIMAL NOT NULL,
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
    CONSTRAINT attachement_instance_id_attachement_fk FOREIGN KEY (id_attachement) REFERENCES attachement(id_attachement) ON DELETE CASCADE
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
    CONSTRAINT attachement_localisation_id_attachement_fk FOREIGN KEY (id_attachement) REFERENCES attachement(id_attachement) ON DELETE CASCADE
);

CREATE TABLE attachement_photo
(
    id_attachement_photo SERIAL,
    id_attachement INTEGER NOT NULL,
    image_url VARCHAR(250) NOT NULL,
    CONSTRAINT attachement_photo_pk PRIMARY KEY (id_attachement_photo),
    CONSTRAINT attachement_photo_id_attachement_fk FOREIGN KEY (id_attachement) REFERENCES attachement(id_attachement) ON DELETE CASCADE
);

CREATE TABLE attachement_projet
(
    id_attachement_projet SERIAL,
    id_projet INTEGER NOT NULL,
    id_attachement_instance INTEGER NOT NULL,
    CONSTRAINT attachement_projet_pk PRIMARY KEY (id_attachement_projet),
    CONSTRAINT attachement_projet_id_projet_fk FOREIGN KEY (id_projet) REFERENCES projet(id_projet) ON DELETE CASCADE,
    CONSTRAINT attachement_projet_id_attachement_instance_fk FOREIGN KEY (id_attachement_instance) REFERENCES attachement_instance(id_attachement_instance) ON DELETE CASCADE
);

CREATE TABLE permission
(
    id_permission SERIAL,
    code VARCHAR NOT NULL,
    nom_fr VARCHAR,
	nom_en VARCHAR,
    CONSTRAINT permission_pk PRIMARY KEY (id_permission)
);

CREATE TABLE role
(
    id_role SERIAL,
    nom VARCHAR NOT NULL,
    CONSTRAINT role_pk PRIMARY KEY (id_role)
);

CREATE TABLE role_permission
(
    id_role INTEGER NOT NULL,
    id_permission INTEGER NOT NULL,
    CONSTRAINT role_permission_pk PRIMARY KEY (id_role, id_permission)
);


CREATE TABLE utilisateur
(
    id_utilisateur SERIAL,
    nom VARCHAR NOT NULL,
    mot_de_passe VARCHAR NOT NULL,
	id_role INTEGER NOT NULL,
    CONSTRAINT utilisateur_pk PRIMARY KEY (id_utilisateur),
    CONSTRAINT role_id_role_fk FOREIGN KEY (id_role) REFERENCES Role(id_role)
);


INSERT INTO client (adresse_principale, adresse_secondaire, telephone, nom_contact, courriel, site_web) VALUES ('123 adresse principale', ' 123 adresse secondaire', '5141234567', 'John Doe', 'john@doe.com', 'http://google.com');
INSERT INTO client (adresse_principale, adresse_secondaire, telephone, nom_contact, courriel, site_web) VALUES ('456 adresse principale', ' 456 adresse secondaire', '5147654321', 'Jane Roe', 'jane@roe.com', 'http://google.com');

INSERT INTO membre (nom_complet, telephone) VALUES ('John Doe', '5141234567');
INSERT INTO membre (nom_complet, telephone) VALUES ('Jane Roe', '5147654321');

INSERT INTO projet (nom) VALUES ('projet 1');
INSERT INTO projet (nom) VALUES ('projet 2');

INSERT INTO projet_membre (id_projet, id_membre) VALUES (1, 1);
INSERT INTO projet_membre (id_projet, id_membre) VALUES (2, 2);

INSERT INTO projet_photo (id_projet, image_url) VALUES (1, 'http://via.placeholder.com/250/1CBD72');
INSERT INTO projet_photo (id_projet, image_url) VALUES (2, 'http://via.placeholder.com/250/2D3DE6');

INSERT INTO machine (marque, modele, hauteur, largeur, poids, capacite, nb_heure_entre_entretient, type_compatibilite) VALUES ('marque 1', 'modele 1', 10, 10, 20, 100, 1000, 'type compatibilite 1');
INSERT INTO machine (marque, modele, hauteur, largeur, poids, capacite, nb_heure_entre_entretient, type_compatibilite) VALUES ('marque 2', 'modele 2', 20, 20, 40, 200, 2000, 'type compatibilite 2');

INSERT INTO machine_instance (id_machine, nb_heure_utilisation, numero_serie, description) VALUES (1, 200, 'numero serie 1', 'description 1');
INSERT INTO machine_instance (id_machine, nb_heure_utilisation, numero_serie, description) VALUES (2, 1000, 'numero serie 2', 'description 2');

INSERT INTO machine_projet (id_projet, id_machine_instance) VALUES (1, 1);
INSERT INTO machine_projet (id_projet, id_machine_instance) VALUES (2, 2);

INSERT INTO machine_photo (id_machine, image_url) VALUES (1, 'http://via.placeholder.com/250/1CBD72');
INSERT INTO machine_photo (id_machine, image_url) VALUES (2, 'http://via.placeholder.com/250/2D3DE6');

INSERT INTO machine_localisation (id_machine, description, remarque) VALUES (1, 'description 1', 'remarque 1');
INSERT INTO machine_localisation (id_machine, description, remarque) VALUES (2, 'description 2', 'remarque 2');

INSERT INTO machine_instance_photo (id_machine_instance, image_url) VALUES (1, 'http://via.placeholder.com/250/1CBD72');
INSERT INTO machine_instance_photo (id_machine_instance, image_url) VALUES (2, 'http://via.placeholder.com/250/2D3DE6');

INSERT INTO attachement (numero_attachement, numero_serie, type_compatibilite, marque, modele, hauteur, largeur, nb_heure_entre_entretient) VALUES ('no attachement 1', 'no serie 1', 'type compatibilite 1', 'marque 1', 'modele 1', 10, 20, 100);
INSERT INTO attachement (numero_attachement, numero_serie, type_compatibilite, marque, modele, hauteur, largeur, nb_heure_entre_entretient) VALUES ('no attachement 2', 'no serie 2', 'type compatibilite 2', 'marque 2', 'modele 2', 20, 40, 2000);

INSERT INTO attachement_instance (id_attachement, etat_general, type_compatibilite, nb_heure_entre_entretient) VALUES (1, 'etat general 1', 'type compatibilite 1', 100);
INSERT INTO attachement_instance (id_attachement, etat_general, type_compatibilite, nb_heure_entre_entretient) VALUES (2, 'etat general 2', 'type compatibilite 2', 200);

INSERT INTO attachement_localisation (id_attachement, description, remarque, gamme_produit, classe, classement, division, industrie, produit) VALUES (1, 'description 1', 'remarque 1', 'gamme produit 1', 'classe 1', 'classement 1', 'division 1', 'industrie 1', 'produit 1');
INSERT INTO attachement_localisation (id_attachement, description, remarque, gamme_produit, classe, classement, division, industrie, produit) VALUES (2, 'description 2', 'remarque 2', 'gamme produit 2', 'classe 2', 'classement 2', 'division 2', 'industrie 2', 'produit 2');

INSERT INTO attachement_photo (id_attachement, image_url) VALUES (1, 'http://via.placeholder.com/250/1CBD72');
INSERT INTO attachement_photo (id_attachement, image_url) VALUES (2, 'http://via.placeholder.com/250/2D3DE6');

INSERT INTO attachement_projet (id_projet, id_attachement_instance) VALUES (1, 1);
INSERT INTO attachement_projet (id_projet, id_attachement_instance) VALUES (2, 2);

INSERT INTO role (nom) VALUES ('superAdmin');

INSERT INTO permission (code, nom_fr, nom_en) VALUES ('addUser', 'ajouter utilisateurs', 'add users'); 
INSERT INTO permission (code, nom_fr, nom_en) VALUES ('manageUser', 'Gérer les utilisateurs', 'manage users'); 
INSERT INTO permission (code, nom_fr, nom_en) VALUES ('removeUser', 'supprimer les utilisateurs', 'remove users'); 
INSERT INTO permission (code, nom_fr, nom_en) VALUES ('manageRole', 'Gérer les roles', 'manage roles'); 

INSERT INTO utilisateur (nom, mot_de_passe, id_role) VALUES ('admin', 'AHY5s+PQwNC13fpWm7OYAtkk2MYFx0pM9zgVyeMFnKkjofUy+xx5jUH96COQg2VhRw==', 1);

INSERT into role_permission (id_role, id_permission) VALUES (1,1);
INSERT into role_permission (id_role, id_permission) VALUES (1,2);
INSERT into role_permission (id_role, id_permission) VALUES (1,3);
INSERT into role_permission (id_role, id_permission) VALUES (1,4);
COMMIT;
