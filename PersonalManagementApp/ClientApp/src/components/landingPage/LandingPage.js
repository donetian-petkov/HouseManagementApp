import '../../assets/landingPage/dist/css/style.css';
import ScriptTag from 'react-script-tag';


const LandingPage = () => {

    return (
        <div className="is-boxed has-animations">
            <ScriptTag type="text/javascript" src="/assets/landingPage/dist/js/main.min.js" />
            <div className="body-wrap boxed-container">

                <main>
                    <section className="hero">
                        <div className="container">
                            <div className="hero-inner">
                                <div className="hero-copy">
                                    <h1 className="hero-title mt-0">Personal Management App</h1>
                                    <p className="hero-paragraph">These are the tools for managing your time and
                                        schedule</p>
                                </div>
                            </div>
                        </div>
                    </section>
                </main>

            </div>
        </div>
    )
}

export default LandingPage;