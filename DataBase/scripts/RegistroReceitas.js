db.createCollection("RegistroReceitas", {
  validator: {
    bsonType: "object",
    required: ["DadaCadastro", "DataPagamento", "Status", "CodigoReceita", "EstaAgendado"],
    properties: {
      DadaCadastro: {
        bsonType: "Date"
      },
	  DataPagamento: {
        bsonType: "Date"
      },
      EstaAgendado: {
        bsonType: "bool"
      },
      Status: {
        bsonType: "int"
      },
      CodigoReceita: {
        bsonType: "int"
      }
    }
  },
  validationLevel: "moderate",
  validationAction: "warn"
});

db.getCollection("RegistroReceitas").createIndex({ "CodigoReceita": 1 });
db.getCollection("RegistroReceitas").createIndex({ "DadaCadastro": 1 });
db.getCollection("RegistroReceitas").createIndex({ "DataPagamento": 1 });
db.getCollection("RegistroReceitas").createIndex({ "Status": 1 });
