Module Module1

    Sub Main()
        Dim url As String = "http://10.10.0.75/ServiciosCLIN.asmx/reporteDiarioOtrosMedios?USUARIO=primerBT&CREDENCIAL=testuif&LICENCIA=&MAC=61:PR:TR:01:06:17&IP=&EMPRESA=primerBT&idRegistroBancario=PBT&cargoColaborador=&codigoColaborador=nrodas&fechaTransaccion=2017-01-01&distintoAlCliente=1&tipoTransaccion=1&numeroProducto=6465665&claseProducto=NO DEFINIDO&montoTransaccion=1522.000000&valorOtrosMedios=0.000000&conceptoTransaccion=pago de prestamo&PSdireccionAgencia=Calle 2, No 3, Colonia Escalon&PSidDepartamento=&PSidMunicipio=&PTprimerApellido=LOERA&PTsegundoApellido=&PTapellidoCasado=&PTprimerNombre=JOAQUIN&PTsegundoNombre=&PTfechaNacimiento=2017-05-02&PTlugarNacimiento=&PTcodigoNacionalidad=&PTcodigoEstadoCivil=&PTtipoDocumento=1&PTnumeroDocumento=&PTpersonaDomicilio=&PTcodigoMunicipio=&PTcodigoDepartamento=&PTprofesionPersona=&tipoPersonaB=&PBprimerApellido=LOERA&PBsegundoApellido=&PBapellidoCasado=&PBprimerNombre=JOAQUIN&PBsegundoNombre=&PBfechaNacimiento=2017-05-02&PBlugarNacimiento=&PBcodigoNacionalidad=&PBcodigoEstadoCivil=&PBtipoDocumento=1&PBnumeroDocumento=&PBpersonaDomicilio=&PBcodigoMunicipio=&PBcodigoDepartamento=&PBprofesionPersona=&PJBrazonSocial=JOAQUIN   LOERA  &PJBdomicilioComercial=&PJBactividadEconomica=&PJBtipoIdentificacionT=1&PJBnumeroIdentificacionT=&tipoPersonaC=&PCprimerApellido=LOERA&PCsegundoApellido=&PCapellidoCasado=&PCprimerNombre=JOAQUIN&PCsegundoNombre=&PCfechaNacimiento=2017-05-02&PClugarNacimiento=&PCcodigoNacionalidad=&PCcodigoEstadoCivil=&PCtipoDocumento=1&PCnumeroDocumento=&PCpersonaDomicilio=&PCcodigoMunicipio=&PCcodigoDepartamento=&PCprofesionPersona=&PJCrazonSocial=JOAQUIN   LOERA  &PJCdomicilioComercial=&PJCactividadEconomica=&PJCtipoIdentificacionT=1&PJCnumeroIdentificacionT=&tipoPersona="
        Console.WriteLine(valorUrl(url, "PSdireccionAgencia"))
        Console.WriteLine(valorUrl(url, "montoTransaccion"))
        Console.ReadLine()
    End Sub

    Public Function valorUrl(ByVal url As String, ByVal nombre As String) As String
        url = url.Substring(url.LastIndexOf("?") + 1) 'se toma solo los parametros de la url
        Dim resultado As String = ""
        Dim parametros() As String = url.Split("&") 'delimitador
        For Each p As String In parametros
            Dim v() As String = p.Split("=")
            Dim indice As String = v(0) 'variable
            Dim valor As String = v(1) 'valor
            If indice = nombre Then 'si la variable coincide con el nombre del parametro
                resultado = valor
                Exit For
            End If
        Next
        Return resultado
    End Function
End Module
