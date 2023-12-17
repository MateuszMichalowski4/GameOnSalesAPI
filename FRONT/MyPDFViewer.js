import React, { useState } from 'react';
import './DownloadPdfForm.css';

const DownloadPdfForm = () => {
    const [name, setName] = useState('');
    const [surname, setSurname] = useState('');
    const [experience, setExperience] = useState('');
    const [fileName, setFileName] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');
    const [languages, setLanguages] = useState('');
    const [interests, setInterests] = useState('');
    const [githubLink, setGithubLink] = useState('');
    const [email, setEmail] = useState('');
    const [education, setEducation] = useState('');

    const handleSubmit = async (event) => {
        event.preventDefault();
        const response = await fetch(`https://localhost:7296/Pdf/generatepdf/${fileName}?name=${name}&surname=${surname}&experience=${experience}&phoneNumber=${phoneNumber}&languages=${languages}&interests=${interests}&githubLink=${githubLink}&email=${email}&education=${education}`);
        const blob = await response.blob();
        
        const url = window.URL.createObjectURL(blob);
        const link = document.createElement('a');
        link.href = url;
        link.setAttribute('download', `${fileName}.pdf`);
        document.body.appendChild(link);
        link.click();
    }

    return (
        <form onSubmit={handleSubmit} className='DownloadPdfForm'>
            <label>
                Imię:
                <input type="text" value={name} onChange={e => setName(e.target.value)} />
            </label>
            <label>
                Nazwisko:
                <input type="text" value={surname} onChange={e => setSurname(e.target.value)} />
            </label>
            <label>
                Github:
                <input type="text" value={githubLink} onChange={e => setGithubLink(e.target.value)}/>
            </label>
            <lable>
                Email:
                <input type='text' value={email} onChange={e=> setEmail(e.target.value)}/>
            </lable>
            <label>
                Numer telefonu:
                <input type="text" value={phoneNumber} onChange={e => setPhoneNumber(e.target.value)} />
            </label>
            <label>
                Znajomość języków:
                <input type="text" value={languages} onChange={e => setLanguages(e.target.value)} />
            </label>
            <label>
                Edukacja:
                <input type='text' value={education} onChange={e => setEducation(e.target.value)}/>
            </label>
            <label>
                Doświadczenie:
                <textarea value={experience} onChange={e => setExperience(e.target.value)} />
            </label>
            <label>
                Zainteresowania:
                <input type="text" value={interests} onChange={e => setInterests(e.target.value)} />
            </label>
            <label>
                Nazwa pliku:
                <input type="text" value={fileName} onChange={e => setFileName(e.target.value)} />
            </label>
            <button type="submit">Generuj PDF</button>
        </form>
    );
}

export default DownloadPdfForm;

