const {env} = require('process');

const target = env.ASPNETCORE_HTTP_PORT ? `https://localhost:${env.ASPNETCORE_HTTP_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:13251';

const PROXY_CONFIG = [
  {
    context: [
      "/api",
      "/swagger"
    ],
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
