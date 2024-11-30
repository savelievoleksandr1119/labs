const RenovationModel = require('../models/renovationModel');

exports.getRenovations = (req, res) => {
    const renovations = RenovationModel.getAllRenovations();
    res.render('renovationListView', { renovations });
};

exports.getRenovation = (req, res) => {
    const renovations = RenovationModel.getAllRenovations();
    const id = req.params['id'];
    const renovation = renovations.find(x => x.id == id);
    res.render('renovationView', { renovation });
};

exports.getPrivacy = (req, res) => {
    res.render('privacyView');
};

exports.getAbout = (req, res) => {
    res.render('aboutView');
};

exports.createRenovation = (req, res) => {
    const newRenovation = { id: Date.now(), name: req.body.name, description: req.body.description };
    RenovationModel.addRenovation(newRenovation);
    res.redirect('/');
};