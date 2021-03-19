let url = 'http://localhost:5544/kvs/testcall';

const http = require('http');


// testcall GET
http.get(url, (res) => {
  res.on('data', (chunk)=>{
    console.log('response with data received');
    console.log(chunk.toString());
  })
});



// testcall PUT
const data = '=valueHere';

const options = {
  hostname: 'localhost',
  port: 5544,
  path: '/kvs/testcall',
  method: 'PUT',
  headers: {
    'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
  }
};

const req = http.request(options, (res) => {
  console.log('statusCode:', res.statusCode);
  res.on('data', (data) => {
    process.stdout.write(data);
  });
});

req.on('error', (e) => {
  console.error(e);
});

req.write(data)
req.end();