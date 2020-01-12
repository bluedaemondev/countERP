# countERP
<p>Blackmood games & software</p>
<p>Argentina.</p>
<p>contact me: <a href="mailto:blackmoodgames@gmail.com">blackmoodgames@gmail.com</a></p>
""countERP - open source""
  <p>
12 de septiembre del 2019
  </p>
<div>
  <h2>VISIÓN GENERAL</h2>
<p>Este proyecto estará basado en la plataforma .Net Core 3.1, sobre la cual se crearán módulos reutilizables, heredables y modificables completamente.</p>
  </div>
<div>
  <h2>OBJETIVOS</h2>
<p>Desarrollar la plataforma base, que consiste en un máximo de 30 entidades/modelo. Se realizará la interfaz visual a través de Web, utilizando frameworks de desarrollo de front y backend, como puede ser (a necesidad) d3, underscore.js, Angular o similares,. También a nivel interfaz, nos basaremos en paletas prediseñadas, con elementos faciles de replicar (templates) con bootstrap y algun otro modulo copado.
Se realizará una prueba en el negocio instalado de álvaro para pulir detalles de interfaz, realizando ajustes a medida y generales.</p>
  <p>Con la primera iteración lista, nos dedicaremos a la mejora progresiva, desarrollando módulos externos, subidos a repositorios y documentados correctamente.</p>
<h2>ESPECIFICACIONES y REQUISITOS</h2>
  <p>El entorno de servidor va a estar diseñado para correr en una máquina junto con el entorno de cliente. Esto permitirá reducir costos, y podremos acceder en local a través de teamviewer para realizar updates/instalaciones de módulos nuevos.</p>
  <ul>
    <li>
      Servidor de base de datos SQL server, sin entorno gráfico.</li>
    <li>Servicio web de la aplicación (DNS Local)</li>
    <li>Vpn para acceso por terminal</li>
    <li>Manual de usuario</li>
    <li>Navegador web Chrome montado en Windows 10.</li>
  </ul>
   </div>
  <div>
  <h2>HITOS del DESARROLLO</h2>
<p>(20) clases que correspondan a un entorno base.
  +/- 20 entidades, en las cuales se encuentran las siguientes, agrupadas:</p>
<code>productos : product_category , product_uom , product_template , product_product , stock_move , stock_move_line</code>
<code>entidades : res_company , res_partner , hr_employee , hr_contract , res_user , res_group , res_group_rule , res_group_rule_rel</code>
  <code>comercio : sale_order , account_invoice , sale_order_line , account_invoice_line , res_currency , res_currency_rate , purchase_order , purchase_order_line</code>
<code>Extras: 
point_of_sale , pos_config</code>
<p>Interfaz hecha por templates para ingreso de datos
Las vistas correspondientes a cada uno de los modelos. que incluirán ventanas de listado de productos por categoría, sólo productos, vistas de formulario de sale/purchase/invoice.
Interfaz de punto de venta.
Plataforma para empleado con restricción a solo ventas. Puede producir tanto sale orders, como purchase orders.
  </p>
  </div>
  <p>
Este proyecto está planificado para el siguiente cronograma y fecha:
Fecha de publicacion de la primera iteración: 20/12/2019
10 - 11 - 12 - 13 de diciembre 2019: finalización de las entidades en SQL. (DONE)
11 - 13 de diciembre 2019 : vistas completas de modelos de producto y sale order (WIP)
15 - 16 - 17 de enero desarrollo del POS (WIP)
<p>
</div>

