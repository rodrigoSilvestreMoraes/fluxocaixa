db.createCollection("Receitas", {
  validator: {
    bsonType: "object",
    required: ["Nome"],
    properties: {
      Nome: {
        bsonType: "string"
      }
    }
  },
  validationLevel: "moderate",
  validationAction: "warn"
});

db.getCollection("Receitas").createIndex({ "Nome": 1 });

db.Receitas.insertMany([{Nome: "Venda de Produto"}]);
db.Receitas.insertMany([{Nome: "Investimento"}]);
db.Receitas.insertMany([{Nome: "Aporte de Capital"}]);
db.Receitas.insertMany([{Nome: "Rendimento de Fundos"}]);
