# WebShop
## Avancement du projet

- [x] initialisation de la DB MonWebShop
- [x] Lien DB entre les clients et netUser
- [ ] modif du css
- [ ] modif du formulaire d'enregistrement des utilisateurs
- [ ] enregistrement des session ( avec le role utilisateur ou admin)

## home
- [ ] controleur home avec une methode index qui renvoit la liste des articles et redirige vers la bonne vue en fonction du role de l'utilisateur
- [ ] une vue indexAdmin comprennant un grid ou datatable pour afficher les articles
- [ ] les bouton supprimer, modifier, ajouter article pour l'admin
- [ ] une vue indexUser comprennant un grid ou datatable pour afficher les articles
- [ ] les boutons details pour les utilisateurs
- [ ] une methode search (ou autre) dans le controleur qui premet l'affichage des listes pour le tri

## article
- [ ] vue detail article
- [ ] methode delete article dans le controleur article
- [ ] methode detail article dans le controleur article
- [ ] methode edit article dans le controleur article
- [ ] methode create article dans le controleur article

## panier
- [ ] vue panier de l'utilisateur (il faut verifier la session)
- [ ] methode add dans le controleur panier pour ajouter un article au panier
- [ ] methode remove dans le controleur panier pour supprimer un article au panier

## commande
- [ ] vue commande qui affiche toutes les commandes des utilisateurs (il faut verifier la session)
- [ ] methode detail dans le controleur commande qui affiche le detail d'une commande
- [ ] methode setDelivrering qui permet de changer le statut d'une commande en "livraison en cours" (admin seulement)
- [ ] methode setDelivrered qui permet de changer le statut d'une commande en "livraison terminée" (admin seulement)
