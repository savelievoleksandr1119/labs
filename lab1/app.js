const express = require('express');
var bodyParser = require('body-parser');

const app = express();
const renovationRoutes = require('./routes/renovationRoutes');

app.use(bodyParser.json());
app.use(bodyParser.urlencoded());

app.use(bodyParser.urlencoded({ extended: true }));

app.set('view engine', 'ejs');
app.use('/', renovationRoutes);

app.listen(3000, () => {
    console.log('Server is running on port 3000');
});
