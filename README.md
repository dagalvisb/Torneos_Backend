

puedes clonar el repositorio usando los comandos en el bash

```bash
git clone https://github.com/dagalvisb/Proyecto_Torneos.git
```

aqui descargaras el Frontend y el backend en 2 carpetas diferentes especificadas cada una con el respectivo nombre.

- El Frontend es recomendable abrirlo en Visual Studi Code

luego de abrir el Frontend deberemos descargar las dependencias usando 
```bash
npm Install
```
para iniciar el Frontenn:

```bash
ng serve
```

- El Backend es recomendable abrirlo en Visual Studio 2022

Este proyecto usa una DB de Postgres, por lo tanto deberemos crear nuestra base de datos con el nombre "TorneosDb",
puede ser en PgAdmin 4 o en DBeaver, o el Framework de tu preferencia.

En el appsettings.json deberas poner la contraseña de tu postgres en el espacio que dice "Tu contraseña" la otra informacion quedara igual, a no ser que tu Username no sea "postgres" en el caso de que no sea, poner tu Username en el espacio "Username"

luego de esto en el powershel del Visual Studio deberemos hacer el "update-database" para generar la base de datos.

En la Carpeta Database/StoredProcedures encontraran 3 procedimientos almacenados los cuales deberemos iniciar en el Framework.



cuando el servicio este corriendo, abrir el navegador en `http://localhost:4200/`. la aplicasion se activara automaticamente


- para ejecutar los Test Unitarios del Frontend usamios [Karma](https://karma-runner.github.io) usando el siguiente comando:

solo hay Unit test en las siguientes rutas

```bash
ng test --include='src\app\features\equipos\detail\detail.component.spec.ts'
```

```bash
ng test --include='src\app\features\jugadores\form\form.component.spec.ts'
```

```bash
ng test --include='src\app\features\partidos\list\list.component.spec.ts'
```

- para ejecutar el Test del Backend solo debemos darle click derecho en el unit test del back y Ejecutarlo.

- para detener el proyecto usamos:

Ctrl + C en el Terminarl del Frontend

Ctrl + C en la Terminal que genera el Backend 




