const express = require('express');
const router = express.Router();
const renovationController = require('../controllers/renovationController');

router.get('/', renovationController.getRenovations);
router.get('/item/:id', renovationController.getRenovation);
router.get('/privacy', renovationController.getPrivacy);
router.get('/about', renovationController.getAbout);
router.post('/create', renovationController.createRenovation);

module.exports = router;
