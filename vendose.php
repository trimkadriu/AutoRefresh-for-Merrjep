<?php

error_reporting(0);

$url = $_POST["url"];
$password = $_POST["password"];
$return_message = "SUCCESS";
header('Content-Type: application/json');

function getRequest() {
    global $url;
    $ch = curl_init();
    $curlConfig = array(
        CURLOPT_URL            => $url,
        CURLOPT_POST           => false,
        CURLOPT_RETURNTRANSFER => true,
    );
    curl_setopt_array($ch, $curlConfig);
    $result = curl_exec($ch);
    curl_close($ch);
    return $result;
}

function postRequest($url, $data) {
    global $ch;
    $ch = curl_init();
    $curlConfig = array(
        CURLOPT_URL            => $url,
        CURLOPT_POST           => true,
        CURLOPT_RETURNTRANSFER => true,
        CURLOPT_POSTFIELDS     => $data,
        CURLINFO_HEADER_OUT    => true
    );
    curl_setopt_array($ch, $curlConfig);
    $result = curl_exec($ch);
    //print_r(curl_getinfo($ch)); echo '<br/><br/>';
    //print_r($result);
    curl_close($ch);
    return $result;
}

function getValuesOfElements($element) {
    if($element != null)
        return $element->getAttribute('value');
    return '';
}

function getValueOfElementByAttributeName($elements, $name) {
    foreach($elements as $element) {
        if($element->getAttribute('name') == $name) {
            return getValuesOfElements($element);
            break;
        }
    }
}

function getSelectedValueOfSelectElement($elements) {
    foreach($elements as $element) {
        if($element->getAttribute('selected') == 'selected') {
            return getValuesOfElements($element);
            break;
        }
    }
}

if(!isset($url) || trim($url) === '' || !isset($password) || trim($password) === '') {
    $return_message = "ERROR";
}
else {
    $itemId = substr($url, strrpos($url, "=") + 1, strlen($url));

    try {
        // ==========================================================================================================
        //                                            FIRST REQUEST DATA
        // ==========================================================================================================
        $DOM = new DOMDocument;
        $DOM->loadHTML(getRequest());
        $firstResultData = array(
            'ctl00_ContentPlaceHolder1_TabContainer1_ClientState' => getValuesOfElements($DOM->getElementById('ctl00_ContentPlaceHolder1_TabContainer1_ClientState')),
            '__EVENTTARGET' => getValuesOfElements($DOM->getElementById('__EVENTTARGET')),
            '__EVENTARGUMENT' => getValuesOfElements($DOM->getElementById('__EVENTARGUMENT')),
            '__VIEWSTATE' => getValuesOfElements($DOM->getElementById('__VIEWSTATE')),
            'ctl00$ContentPlaceHolder1$TabContainer1$TabPanel1$NameTextBox' => '',
            'ctl00$ContentPlaceHolder1$TabContainer1$TabPanel1$EmailAddressTextBox' => '',
            'ctl00$ContentPlaceHolder1$TabContainer1$TabPanel1$TelephoneTextBox' => '',
            'ctl00$ContentPlaceHolder1$TabContainer1$TabPanel1$MessageTextBox' => '',
            'ctl00$ContentPlaceHolder1$TipNameTextBox' => '',
            'ctl00$ContentPlaceHolder1$TipEmailAddressTextBox' => '',
            'ctl00$ContentPlaceHolder1$TipMessageTextBox' => '',
            'ctl00$ContentPlaceHolder1$TabContainer1$TabPanel3$EditAlternativeRadioButtonList' => '1',
            'ctl00$ContentPlaceHolder1$TabContainer1$TabPanel3$PasswordTextBox' => $password,
            'ctl00$ContentPlaceHolder1$TabContainer1$TabPanel3$EditButton' => 'Vazhdoje'
        );


        // ==========================================================================================================
        //                                            SECOND REQUEST DATA
        // ==========================================================================================================
        $DOM->loadHTML(postRequest($url, $firstResultData));
        $secondResultData = array(
            '__eo_obj_states' => getValuesOfElements($DOM->getElementById('__eo_obj_states')),
            '__eo_sc' => getValuesOfElements($DOM->getElementById('__eo_sc')),
            '__EVENTTARGET' => getValuesOfElements($DOM->getElementById('__EVENTTARGET')),
            '__EVENTARGUMENT' => getValuesOfElements($DOM->getElementById('__EVENTARGUMENT')),
            '__LASTFOCUS' => getValuesOfElements($DOM->getElementById('__LASTFOCUS')),
            '__VIEWSTATE' => getValuesOfElements($DOM->getElementById('__VIEWSTATE')),
            'eo_version' => getValueOfElementByAttributeName($DOM->getElementsByTagName('input'), 'eo_version'),
            'eo_style_keys' => getValueOfElementByAttributeName($DOM->getElementsByTagName('input'), 'eo_style_keys'),
            'ctl00$ContentPlaceHolder1$Wizard1$MunicipalityDropDownList' => getValuesOfElements($DOM->getElementById('ctl00_ContentPlaceHolder1_Wizard1_MunicipalityDropDownList')),
            'ctl00$ContentPlaceHolder1$Wizard1$MunicipalityDropDownList_CascadingDropDown_ClientState' =>  getValuesOfElements($DOM->getElementById('ctl00_ContentPlaceHolder1_Wizard1_MunicipalityDropDownList_CascadingDropDown_ClientState')),
            'ctl00$ContentPlaceHolder1$Wizard1$NameTextBox' =>  getValuesOfElements($DOM->getElementById('ctl00_ContentPlaceHolder1_Wizard1_NameTextBox')),
            'ctl00$ContentPlaceHolder1$Wizard1$EmailTextBox' =>  getValuesOfElements($DOM->getElementById('ctl00_ContentPlaceHolder1_Wizard1_EmailTextBox')),
            'ctl00$ContentPlaceHolder1$Wizard1$TelephoneTextBox' =>  getValuesOfElements($DOM->getElementById('ctl00_ContentPlaceHolder1_Wizard1_TelephoneTextBox')),
            'ctl00$ContentPlaceHolder1$Wizard1$CategoryDropDownList_CascadingDropDown_ClientState' =>  getValuesOfElements($DOM->getElementById('ctl00_ContentPlaceHolder1_Wizard1_CategoryDropDownList_CascadingDropDown_ClientState')),
            'ctl00$ContentPlaceHolder1$Wizard1$CategoryTypeDropDownList_CascadingDropDown_ClientState' =>  getValuesOfElements($DOM->getElementById('ctl00_ContentPlaceHolder1_Wizard1_CategoryTypeDropDownList_CascadingDropDown_ClientState')),
            'ctl00$ContentPlaceHolder1$Wizard1$NbrRoomsDropDownList' =>  getSelectedValueOfSelectElement($DOM->getElementById('ctl00_ContentPlaceHolder1_Wizard1_NbrRoomsDropDownList')->childNodes),
            'ctl00$ContentPlaceHolder1$Wizard1$LivingareaTextBox' =>  getValuesOfElements($DOM->getElementById('ctl00_ContentPlaceHolder1_Wizard1_LivingareaTextBox')),
            'ctl00$ContentPlaceHolder1$Wizard1$HeadlineTextBox' =>  getValuesOfElements($DOM->getElementById('ctl00_ContentPlaceHolder1_Wizard1_HeadlineTextBox')),
            'ctl00$ContentPlaceHolder1$Wizard1$DescriptionTextBox' => $DOM->getElementById('ctl00_ContentPlaceHolder1_Wizard1_DescriptionTextBox')->nodeValue,
            'ctl00$ContentPlaceHolder1$Wizard1$PriceTextBox' =>  getValuesOfElements($DOM->getElementById('ctl00_ContentPlaceHolder1_Wizard1_PriceTextBox')),
            '_eo_js_modules' =>  getValuesOfElements($DOM->getElementById('_eo_js_modules')),
            '_eo_js_modules' =>  getValuesOfElements($DOM->getElementById('_eo_js_modules')),
            '_eo_obj_inst' =>  getValuesOfElements($DOM->getElementById('_eo_obj_inst')),
            '_eo_obj_inst' =>  getValuesOfElements($DOM->getElementById('_eo_obj_inst')),
            '_eo_js_modules' =>  getValuesOfElements($DOM->getElementById('_eo_js_modules')),
            '_eo_js_modules' =>  getValuesOfElements($DOM->getElementById('_eo_js_modules')),
            '_eo_obj_inst' =>  getValuesOfElements($DOM->getElementById('_eo_obj_inst')),
            '_eo_obj_inst' =>  getValuesOfElements($DOM->getElementById('_eo_obj_inst')),
            'ctl00$ContentPlaceHolder1$Wizard1$StartNavigationTemplateContainerID$StartNextButton' => 'Gati'
        );

        // ==========================================================================================================
        //                                            THIRD REQUEST DATA
        // ==========================================================================================================
        $secondUrl = "http://www.merrjep.com/RegAd.aspx?itemId=".$itemId;
        $DOM->loadHTML(postRequest($secondUrl, $secondResultData));
        $thirdResultData = array(
            '__eo_obj_states' => getValuesOfElements($DOM->getElementById('__eo_obj_states')),
            '__eo_sc' => getValuesOfElements($DOM->getElementById('__eo_sc')),
            '__EVENTTARGET' => getValuesOfElements($DOM->getElementById('__EVENTTARGET')),
            '__EVENTARGUMENT' => getValuesOfElements($DOM->getElementById('__EVENTARGUMENT')),
            '__VIEWSTATE' => getValuesOfElements($DOM->getElementById('__VIEWSTATE')),
            'eo_version' => getValueOfElementByAttributeName($DOM->getElementsByTagName('input'), 'eo_version'),
            'eo_style_keys' => getValueOfElementByAttributeName($DOM->getElementsByTagName('input'), 'eo_style_keys'),
            'ctl00$ContentPlaceHolder1$Wizard1$PasswordTextBox' => $password,
            'ctl00$ContentPlaceHolder1$Wizard1$VerifyPasswordTextBox' => $password,
            'ctl00$ContentPlaceHolder1$Wizard1$FinishNavigationTemplateContainerID$FinishButton' => 'Lejo'
        );

        $DOM->loadHTML(postRequest($secondUrl, $thirdResultData));

    }
    catch(Exception $e) {}
}

echo json_encode($return_message);


?>